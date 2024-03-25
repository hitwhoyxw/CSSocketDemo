using SocketServerProj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ServerForm : Form
    {
        private readonly NetServerManager netServerManager;
        public ServerForm()
        {
            netServerManager = new NetServerManager();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void startServer_click(object sender, EventArgs e)
        {
            netServerManager.StartServer(new IPEndPoint(IPAddress.Parse(txtBox_ip.Text), int.Parse(txtBox_port.Text)));
            netServerManager.dataReceived += OnDataReceived;
        }

        private void btn_sendClick(object sender, EventArgs e)
        {
           // netServerManager.SendData(Encoding.UTF8.GetBytes(txtBox_Send.Text));
        }

        public void OnDataReceived(object? sender, string msg)
        {
            if (msg == null) { return; }
            Invoke(new Action(() =>
            {
                txtBox_msgList.AppendText(msg);
            }));
        }
    }
}
