namespace DistributionServer
{
    partial class frmDistributionServer
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
            this.lblServerIPAddress = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblGuestTotal = new System.Windows.Forms.Label();
            this.lblCilentInformation = new System.Windows.Forms.Label();
            this.lblCilentStatus = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblServerIPAddress
            // 
            this.lblServerIPAddress.AutoSize = true;
            this.lblServerIPAddress.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerIPAddress.Location = new System.Drawing.Point(30, 30);
            this.lblServerIPAddress.Name = "lblServerIPAddress";
            this.lblServerIPAddress.Size = new System.Drawing.Size(185, 25);
            this.lblServerIPAddress.TabIndex = 0;
            this.lblServerIPAddress.Text = "Server IP Address :";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerPort.Location = new System.Drawing.Point(30, 80);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(126, 25);
            this.lblServerPort.TabIndex = 1;
            this.lblServerPort.Text = "Server Port :";
            // 
            // lblGuestTotal
            // 
            this.lblGuestTotal.AutoSize = true;
            this.lblGuestTotal.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestTotal.Location = new System.Drawing.Point(30, 130);
            this.lblGuestTotal.Name = "lblGuestTotal";
            this.lblGuestTotal.Size = new System.Drawing.Size(123, 25);
            this.lblGuestTotal.TabIndex = 2;
            this.lblGuestTotal.Text = "Guest Total :";
            this.lblGuestTotal.Click += new System.EventHandler(this.lblGuestTotal_Click);
            // 
            // lblCilentInformation
            // 
            this.lblCilentInformation.AutoSize = true;
            this.lblCilentInformation.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCilentInformation.Location = new System.Drawing.Point(33, 180);
            this.lblCilentInformation.Name = "lblCilentInformation";
            this.lblCilentInformation.Size = new System.Drawing.Size(189, 25);
            this.lblCilentInformation.TabIndex = 3;
            this.lblCilentInformation.Text = "Cilent Information :";
            this.lblCilentInformation.Click += new System.EventHandler(this.lblCilentInformation_Click);
            // 
            // lblCilentStatus
            // 
            this.lblCilentStatus.AutoSize = true;
            this.lblCilentStatus.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCilentStatus.Location = new System.Drawing.Point(33, 230);
            this.lblCilentStatus.Name = "lblCilentStatus";
            this.lblCilentStatus.Size = new System.Drawing.Size(136, 25);
            this.lblCilentStatus.TabIndex = 4;
            this.lblCilentStatus.Text = "Cilent Status :";
            // 
            // btnListen
            // 
            this.btnListen.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListen.Location = new System.Drawing.Point(558, 30);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(100, 40);
            this.btnListen.TabIndex = 5;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(558, 80);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerPort.Location = new System.Drawing.Point(162, 77);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 32);
            this.txtServerPort.TabIndex = 7;
            this.txtServerPort.Text = "50000";
            this.txtServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServerPort.Visible = false;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMessage.Location = new System.Drawing.Point(414, 162);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(374, 276);
            this.rtbMessage.TabIndex = 8;
            this.rtbMessage.Text = "";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(414, 130);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(98, 25);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "Message :";
            // 
            // frmDistributionServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.lblCilentStatus);
            this.Controls.Add(this.lblCilentInformation);
            this.Controls.Add(this.lblGuestTotal);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerIPAddress);
            this.Name = "frmDistributionServer";
            this.Text = "Distribution Server";
            this.Load += new System.EventHandler(this.frmDistributionServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerIPAddress;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblGuestTotal;
        private System.Windows.Forms.Label lblCilentInformation;
        private System.Windows.Forms.Label lblCilentStatus;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Label lblMessage;
    }
}

