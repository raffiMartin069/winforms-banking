namespace Martinez_BankApp.View.ParentMdi
{
	partial class ClientMdiForm
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
			this.components = new System.ComponentModel.Container();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.withdrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.depositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fixedDepositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(14, 4, 0, 4);
			this.menuStrip1.Size = new System.Drawing.Size(1434, 27);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "MenuStrip";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionToolStripMenuItem,
            this.withdrawToolStripMenuItem,
            this.depositToolStripMenuItem});
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(79, 19);
			this.toolStripMenuItem2.Text = "&Transaction";
			// 
			// withdrawToolStripMenuItem
			// 
			this.withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
			this.withdrawToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.withdrawToolStripMenuItem.Text = "Withdraw";
			this.withdrawToolStripMenuItem.Click += new System.EventHandler(this.withdrawToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixedDepositToolStripMenuItem});
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(44, 19);
			this.toolStripMenuItem3.Text = "&View";
			// 
			// transactionToolStripMenuItem
			// 
			this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
			this.transactionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.transactionToolStripMenuItem.Text = "Transaction";
			// 
			// depositToolStripMenuItem
			// 
			this.depositToolStripMenuItem.Name = "depositToolStripMenuItem";
			this.depositToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.depositToolStripMenuItem.Text = "Deposit";
			this.depositToolStripMenuItem.Click += new System.EventHandler(this.depositToolStripMenuItem_Click);
			// 
			// fixedDepositToolStripMenuItem
			// 
			this.fixedDepositToolStripMenuItem.Name = "fixedDepositToolStripMenuItem";
			this.fixedDepositToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.fixedDepositToolStripMenuItem.Text = "Fixed Deposit";
			// 
			// ClientMdiForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1434, 861);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.IsMdiContainer = true;
			this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.MinimumSize = new System.Drawing.Size(1450, 900);
			this.Name = "ClientMdiForm";
			this.Text = "ClientMdiForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem withdrawToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem depositToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fixedDepositToolStripMenuItem;
	}
}



