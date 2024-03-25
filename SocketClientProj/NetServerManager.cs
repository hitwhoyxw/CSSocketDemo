using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClientProj
{
    internal class NetServerManager:IDisposable
    {
        public static readonly NetServerManager Instance = new NetServerManager();
        private Socket socket;
        private SocketAsyncEventArgs connectArgs;
        private SocketAsyncEventArgs sendArgs;
        private SocketAsyncEventArgs recvArgs;
        private byte[] recvBytes= new byte[1024];
        private byte[] sendBytes= new byte[1024];
        public event EventHandler<string> OnDataReceived;
        private IPEndPoint iPEndPoint;
        private NetServerManager()
        {

        }
        public  void Connect(IPAddress ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            iPEndPoint=new IPEndPoint(ip,port);
            connectArgs = new SocketAsyncEventArgs() { RemoteEndPoint= iPEndPoint };
            connectArgs.Completed += OnConnectComplete;
            socket.ConnectAsync(connectArgs);
        }

        private void OnConnectComplete(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                return;
            }

            OnDataReceived?.Invoke(this, new MessageFormat("连接到服务器成功" ,e.RemoteEndPoint).ToString());
            //开始接收数据
            recvArgs = new SocketAsyncEventArgs() { RemoteEndPoint=iPEndPoint};
            recvArgs.SetBuffer(recvBytes, 0, recvBytes.Length);
            recvArgs.Completed += OnRecvComplete;
            socket.ReceiveAsync(recvArgs);
        }

        private void OnRecvComplete(object sender, SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred<=0||e.SocketError!=SocketError.Success)
            {
                e.Dispose();
                return;
            }
            string msg = Encoding.UTF8.GetString(recvBytes, 0, e.BytesTransferred);
            OnDataReceived?.Invoke(this, msg);

            socket.ReceiveAsync(recvArgs);
        }

        public void Send(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            Array.Copy(bytes, sendBytes, bytes.Length);
            if (sendArgs == null)
            {
                sendArgs = new SocketAsyncEventArgs() { RemoteEndPoint=iPEndPoint};
                sendArgs.Completed += OnSendComplete;
            }
            sendArgs.SetBuffer(sendBytes, 0, sendBytes.Length);
            if (!socket.SendAsync(sendArgs))
            {
                OnSendComplete(this, sendArgs);
            }
        }

        private void OnSendComplete(object sender, SocketAsyncEventArgs e)
        {
            int length = e.BytesTransferred;
            string msg = Encoding.UTF8.GetString(e.Buffer, 0, length);
            OnDataReceived?.Invoke(this,new MessageFormat("发送成功 "+msg,e.RemoteEndPoint).ToString());
        }

        public void Dispose()
        {
            socket?.Close();
        }
        public void Close()
        {
            //Send("拜拜");
            //socket.DisconnectAsync(connectArgs);
            socket?.Shutdown(SocketShutdown.Both);
        }
    }
}
