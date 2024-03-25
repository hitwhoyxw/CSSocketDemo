using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerProj
{
    //管理socket，网络层数据和UI层数据的交互
    internal class NetServerManager
    {
        public event EventHandler<string?>? dataReceived;
        private IPEndPoint? iPEndPoint;
        private Socket? socket;

        private ConcurrentDictionary<string, Socket> clientSockets = new ConcurrentDictionary<string, Socket>();
        public void StartServer(IPEndPoint iPEndPoint)
        {
            this.iPEndPoint = iPEndPoint;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(iPEndPoint);
            socket.Listen(10);

            StartAccept(null);
        }
        public void StartAccept(SocketAsyncEventArgs? socketAsyncEventArgs)
        {
            if (null == socketAsyncEventArgs)
            {
                socketAsyncEventArgs = new SocketAsyncEventArgs();
                socketAsyncEventArgs.Completed += OnAcceptComplete;
            }
            else
            {
                socketAsyncEventArgs.AcceptSocket = null;
            }
            if (!socket.AcceptAsync(socketAsyncEventArgs))
            {
                ProcessAccept(socketAsyncEventArgs);
            }
        }

        private void ProcessAccept(SocketAsyncEventArgs socketAsyncEventArgs)
        {
            if (socketAsyncEventArgs.SocketError != SocketError.Success)
            {
                return;
            }
            Socket? acceptSocket=socketAsyncEventArgs.AcceptSocket;
            string? remotePoint = acceptSocket?.RemoteEndPoint?.ToString();
            if (remotePoint == null||acceptSocket==null)
            {
                return;
            }
            Socket? connectedSocket;
            if (clientSockets.TryGetValue(remotePoint, out connectedSocket))
            {
                clientSockets.TryUpdate(remotePoint, acceptSocket, connectedSocket);
                connectedSocket.Close();
                connectedSocket = null;
            }
            dataReceived?.Invoke(this, new MessageFormat("连接到服务器", acceptSocket.RemoteEndPoint).ToString());
            SendData(Encoding.UTF8.GetBytes("Welcome to server!"), remotePoint);

            SocketAsyncEventArgs recvArgs = new SocketAsyncEventArgs();
            recvArgs.UserToken = acceptSocket;
            recvArgs.SetBuffer(new byte[1024], 0, 1024);
            recvArgs.Completed += OnIOComplete;
            if (!((Socket)recvArgs.UserToken).ReceiveAsync(recvArgs))
            {
                OnRecvComplete(recvArgs);
            }

            //继续处理连接
            StartAccept(socketAsyncEventArgs);
        }

        private void OnIOComplete(object? sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    OnRecvComplete(e);
                    break;
                case SocketAsyncOperation.Send:
                    break;
            }
        }

        private void OnRecvComplete(SocketAsyncEventArgs recvArgs)
        {
            Socket? connectSocket = recvArgs.UserToken as Socket;
            if (recvArgs.SocketError != SocketError.Success)
            {
                connectSocket?.Shutdown(SocketShutdown.Both);
                connectSocket?.Close();
            }
            int length = recvArgs.BytesTransferred;
            if (length <= 0)
            {
                connectSocket?.Shutdown(SocketShutdown.Both);
                connectSocket?.Close();
            }
            else
            {
                if(recvArgs.Buffer!=null && connectSocket?.RemoteEndPoint != null)
                {
                    string msg = new MessageFormat(Encoding.UTF8.GetString(recvArgs.Buffer, 0, length), connectSocket.RemoteEndPoint).ToString();
                    dataReceived?.Invoke(this, msg);
                }
                if (!connectSocket.ReceiveAsync(recvArgs))
                {
                    OnRecvComplete(recvArgs);
                }
            }
            
            
        }

        private void OnAcceptComplete(object? sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }


        public void SendData(byte[] data,string endPoint)
        {
            int length = data.Length;
            SocketAsyncEventArgs sendArgs = new SocketAsyncEventArgs();
            Socket? token=null;
            if(clientSockets.TryGetValue(endPoint,out token))
            {
                sendArgs.UserToken = token;
                sendArgs.SetBuffer(data, 0, length);
                if (!token.SendAsync(sendArgs))
                {
                    OnSendComplete(sendArgs);
                }
            }
            else
            {
                Debug.WriteLine("SendData failed due to invalid endpoint");
            }
        }

        private void OnSendComplete(SocketAsyncEventArgs sendArgs)
        {
            int length=sendArgs.BytesTransferred;
            string msg = $"发送成功 "+ Encoding.UTF8.GetString(sendArgs.Buffer, 0, length);
            dataReceived?.Invoke(this, msg);
        }
    }
}
