namespace DistributionCilent
{
    partial class frmDistributionCilent
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCilentIPAddress = new System.Windows.Forms.Label();
            this.lblServerIPAddress = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblSend = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblCilentIPAddress
            // 
            this.lblCilentIPAddress.AutoSize = true;
            this.lblCilentIPAddress.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCilentIPAddress.Location = new System.Drawing.Point(30, 30);
            this.lblCilentIPAddress.Name = "lblCilentIPAddress";
            this.lblCilentIPAddress.Size = new System.Drawing.Size(179, 25);
            this.lblCilentIPAddress.TabIndex = 0;
            this.lblCilentIPAddress.Text = "Cilent IP Address :";
            // 
            // lblServerIPAddress
            // 
            this.lblServerIPAddress.AutoSize = true;
            this.lblServerIPAddress.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerIPAddress.Location = new System.Drawing.Point(30, 80);
            this.lblServerIPAddress.Name = "lblServerIPAddress";
            this.lblServerIPAddress.Size = new System.Drawing.Size(185, 25);
            this.lblServerIPAddress.TabIndex = 1;
            this.lblServerIPAddress.Text = "Server IP Address :";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerPort.Location = new System.Drawing.Point(30, 130);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(126, 25);
            this.lblServerPort.TabIndex = 2;
            this.lblServerPort.Text = "Server Port :";
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSend.Location = new System.Drawing.Point(30, 180);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(67, 25);
            this.lblSend.TabIndex = 3;
            this.lblSend.Text = "Send :";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerPort.Location = new System.Drawing.Point(162, 127);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 32);
            this.txtServerPort.TabIndex = 4;
            this.txtServerPort.Text = "50000";
            this.txtServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSend
            // 
            this.txtSend.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSend.Location = new System.Drawing.Point(103, 177);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(382, 32);
            this.txtSend.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(491, 177);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 32);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(640, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 37);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(632, 80);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 37);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(622, 127);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(125, 37);
            this.btnDisconnect.TabIndex = 9;
            this.btnDisconnect.Text = "DisConnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(30, 230);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(98, 25);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Message :";
            // 
            // rtbMessage
            // 
            this.rtbMessage.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMessage.Location = new System.Drawing.Point(134, 230);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(447, 208);
            this.rtbMessage.TabIndex = 11;
            this.rtbMessage.Text = "";
            // 
            // frmDistributionCilent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerIPAddress);
            this.Controls.Add(this.lblCilentIPAddress);
            this.Name = "frmDistributionCilent";
            this.Text = "Distribution Cilent";
            this.Load += new System.EventHandler(this.frmDistributionCilent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCilentIPAddress;
        private System.Windows.Forms.Label lblServerIPAddress;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.RichTextBox rtbMessage;
    }
}

