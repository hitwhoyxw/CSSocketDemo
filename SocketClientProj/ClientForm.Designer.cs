namespace SocketClientProj
{
    partial class ClientForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_ip = new System.Windows.Forms.Label();
            this.txtBox_ip = new System.Windows.Forms.TextBox();
            this.txtBox_port = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txtBox_msgList = new System.Windows.Forms.TextBox();
            this.txtBox_inputField = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(41, 42);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(53, 12);
            this.label_ip.TabIndex = 0;
            this.label_ip.Text = "服务器ip";
            // 
            // txtBox_ip
            // 
            this.txtBox_ip.Location = new System.Drawing.Point(100, 39);
            this.txtBox_ip.Name = "txtBox_ip";
            this.txtBox_ip.Size = new System.Drawing.Size(100, 21);
            this.txtBox_ip.TabIndex = 1;
            // 
            // txtBox_port
            // 
            this.txtBox_port.Location = new System.Drawing.Point(323, 42);
            this.txtBox_port.Name = "txtBox_port";
            this.txtBox_port.Size = new System.Drawing.Size(100, 21);
            this.txtBox_port.TabIndex = 3;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(264, 45);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(41, 12);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "端口号";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(578, 39);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "连接服务器";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txtBox_msgList
            // 
            this.txtBox_msgList.Location = new System.Drawing.Point(43, 83);
            this.txtBox_msgList.Multiline = true;
            this.txtBox_msgList.Name = "txtBox_msgList";
            this.txtBox_msgList.Size = new System.Drawing.Size(718, 302);
            this.txtBox_msgList.TabIndex = 5;
            // 
            // txtBox_inputField
            // 
            this.txtBox_inputField.Location = new System.Drawing.Point(43, 413);
            this.txtBox_inputField.Name = "txtBox_inputField";
            this.txtBox_inputField.Size = new System.Drawing.Size(452, 21);
            this.txtBox_inputField.TabIndex = 6;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(526, 411);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 7;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(686, 39);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "断开连接";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txtBox_inputField);
            this.Controls.Add(this.txtBox_msgList);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txtBox_port);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.txtBox_ip);
            this.Controls.Add(this.label_ip);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.TextBox txtBox_ip;
        private System.Windows.Forms.TextBox txtBox_port;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txtBox_msgList;
        private System.Windows.Forms.TextBox txtBox_inputField;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_close;
    }
}

