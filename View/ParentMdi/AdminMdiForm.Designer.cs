namespace Martinez_BankApp.View.ParentMdi
{
	partial class AdminMdiForm
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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.newAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.withdrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.updateAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listOfCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.depositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fixedDepositFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fixedDepositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenu,
            this.helpMenu,
            this.viewMenu});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1434, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// editMenu
			// 
			this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.newAccountToolStripMenuItem,
            this.updateAccountToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.listOfCustomerToolStripMenuItem});
			this.editMenu.Name = "editMenu";
			this.editMenu.Size = new System.Drawing.Size(64, 20);
			this.editMenu.Text = "&Account";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(143, 6);
			// 
			// newAccountToolStripMenuItem
			// 
			this.newAccountToolStripMenuItem.Name = "newAccountToolStripMenuItem";
			this.newAccountToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.newAccountToolStripMenuItem.Text = "New Account";
			this.newAccountToolStripMenuItem.Click += new System.EventHandler(this.newAccountToolStripMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositToolStripMenuItem,
            this.withdrawToolStripMenuItem,
            this.transferToolStripMenuItem,
            this.fixedDepositFormToolStripMenuItem});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(79, 20);
			this.helpMenu.Text = "&Transaction";
			// 
			// withdrawToolStripMenuItem
			// 
			this.withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
			this.withdrawToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.withdrawToolStripMenuItem.Text = "Withdraw";
			this.withdrawToolStripMenuItem.Click += new System.EventHandler(this.withdrawToolStripMenuItem_Click);
			// 
			// viewMenu
			// 
			this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixedDepositToolStripMenuItem});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(44, 20);
			this.viewMenu.Text = "&View";
			// 
			// updateAccountToolStripMenuItem
			// 
			this.updateAccountToolStripMenuItem.Name = "updateAccountToolStripMenuItem";
			this.updateAccountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.updateAccountToolStripMenuItem.Text = "Update Account";
			this.updateAccountToolStripMenuItem.Click += new System.EventHandler(this.updateAccountToolStripMenuItem_Click);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.searchToolStripMenuItem.Text = "Search";
			// 
			// listOfCustomerToolStripMenuItem
			// 
			this.listOfCustomerToolStripMenuItem.Name = "listOfCustomerToolStripMenuItem";
			this.listOfCustomerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.listOfCustomerToolStripMenuItem.Text = "List of Customer";
			// 
			// depositToolStripMenuItem
			// 
			this.depositToolStripMenuItem.Name = "depositToolStripMenuItem";
			this.depositToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.depositToolStripMenuItem.Text = "Deposit";
			this.depositToolStripMenuItem.Click += new System.EventHandler(this.depositToolStripMenuItem_Click);
			// 
			// transferToolStripMenuItem
			// 
			this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
			this.transferToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.transferToolStripMenuItem.Text = "Transfer";
			// 
			// fixedDepositFormToolStripMenuItem
			// 
			this.fixedDepositFormToolStripMenuItem.Name = "fixedDepositFormToolStripMenuItem";
			this.fixedDepositFormToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.fixedDepositFormToolStripMenuItem.Text = "Fixed Deposit Form";
			// 
			// fixedDepositToolStripMenuItem
			// 
			this.fixedDepositToolStripMenuItem.Name = "fixedDepositToolStripMenuItem";
			this.fixedDepositToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.fixedDepositToolStripMenuItem.Text = "Fixed Deposit";
			// 
			// AdminMdiForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1434, 861);
			this.Controls.Add(this.menuStrip);
			this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1450, 900);
			this.Name = "AdminMdiForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MdiForm";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem editMenu;
		private System.Windows.Forms.ToolStripMenuItem viewMenu;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem newAccountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem withdrawToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateAccountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listOfCustomerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem depositToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fixedDepositFormToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fixedDepositToolStripMenuItem;
	}
}



