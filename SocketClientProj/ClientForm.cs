using System;
using System.Net;
using System.Windows.Forms;

namespace SocketClientProj
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            NetServerManager.Instance.Connect(IPAddress.Parse(txtBox_ip.Text), int.Parse(txtBox_port.Text));
            NetServerManager.Instance.OnDataReceived += UpdateWithData;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            
            NetServerManager.Instance.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            NetServerManager.Instance.Send(txtBox_inputField.Text);
        }

        public void UpdateWithData(object sender,string msg)
        {
            Invoke(new Action(() =>
            {
                txtBox_msgList.AppendText(msg);
            }));
        }
    }
}
