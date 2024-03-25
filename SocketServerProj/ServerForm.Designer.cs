namespace WinFormsApp1
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_startServer = new Button();
            label1 = new Label();
            txtBox_ip = new TextBox();
            txtBox_port = new TextBox();
            label2 = new Label();
            txtBox_Send = new TextBox();
            button2 = new Button();
            txtBox_msgList = new TextBox();
            SuspendLayout();
            // 
            // btn_startServer
            // 
            btn_startServer.Location = new Point(594, 12);
            btn_startServer.Name = "btn_startServer";
            btn_startServer.Size = new Size(93, 47);
            btn_startServer.TabIndex = 0;
            btn_startServer.Text = "启动服务器";
            btn_startServer.UseVisualStyleBackColor = true;
            btn_startServer.Click += startServer_click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 25);
            label1.Name = "label1";
            label1.Size = new Size(55, 17);
            label1.TabIndex = 2;
            label1.Text = "服务器ip";
            // 
            // txtBox_ip
            // 
            txtBox_ip.Location = new Point(106, 22);
            txtBox_ip.Name = "txtBox_ip";
            txtBox_ip.Size = new Size(102, 23);
            txtBox_ip.TabIndex = 3;
            // 
            // txtBox_port
            // 
            txtBox_port.Location = new Point(308, 22);
            txtBox_port.Name = "txtBox_port";
            txtBox_port.Size = new Size(102, 23);
            txtBox_port.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 25);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 4;
            label2.Text = "端口";
            // 
            // txtBox_Send
            // 
            txtBox_Send.Location = new Point(44, 394);
            txtBox_Send.Multiline = true;
            txtBox_Send.Name = "txtBox_Send";
            txtBox_Send.Size = new Size(403, 44);
            txtBox_Send.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(484, 391);
            button2.Name = "button2";
            button2.Size = new Size(120, 47);
            button2.TabIndex = 8;
            button2.Text = "发送";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btn_sendClick;
            // 
            // txtBox_msgList
            // 
            txtBox_msgList.Location = new Point(44, 73);
            txtBox_msgList.Multiline = true;
            txtBox_msgList.Name = "txtBox_msgList";
            txtBox_msgList.Size = new Size(725, 299);
            txtBox_msgList.TabIndex = 1;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(txtBox_Send);
            Controls.Add(txtBox_port);
            Controls.Add(label2);
            Controls.Add(txtBox_ip);
            Controls.Add(label1);
            Controls.Add(txtBox_msgList);
            Controls.Add(btn_startServer);
            Name = "ServerForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_startServer;
        private Label label1;
        private TextBox txtBox_ip;
        private TextBox txtBox_port;
        private Label label2;
        private TextBox txtBox_Send;
        private Button button2;
        private TextBox txtBox_msgList;
    }
}