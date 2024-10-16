﻿namespace Martinez_BankApp.View.Forms.Admin
{
	partial class AdminWithdrawForm
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label8 = new System.Windows.Forms.Label();
			this.OldBalanceTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.AmountTextBox = new System.Windows.Forms.TextBox();
			this.AccountNumberTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ModeComboBox = new System.Windows.Forms.ComboBox();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.ClearAllFieldButton = new System.Windows.Forms.Button();
			this.sample = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label15 = new System.Windows.Forms.Label();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label12, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(1400, 70);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1400, 70);
			this.tableLayoutPanel1.TabIndex = 16;
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(192)))), ((int)(((byte)(47)))));
			this.label11.Location = new System.Drawing.Point(488, 0);
			this.label11.Margin = new System.Windows.Forms.Padding(0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(423, 45);
			this.label11.TabIndex = 2;
			this.label11.Text = "Philippine Community Bank";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(595, 45);
			this.label12.Margin = new System.Windows.Forms.Padding(0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(209, 21);
			this.label12.TabIndex = 2;
			this.label12.Text = "Admin Account Withdrawal";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.label8, 0, 8);
			this.tableLayoutPanel2.Controls.Add(this.OldBalanceTextBox, 1, 7);
			this.tableLayoutPanel2.Controls.Add(this.label7, 0, 7);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.AmountTextBox, 1, 10);
			this.tableLayoutPanel2.Controls.Add(this.AccountNumberTextBox, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label9, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.label5, 0, 10);
			this.tableLayoutPanel2.Controls.Add(this.ModeComboBox, 1, 8);
			this.tableLayoutPanel2.Controls.Add(this.NameTextBox, 1, 5);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 11;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(602, 220);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(3, 136);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(135, 21);
			this.label8.TabIndex = 14;
			this.label8.Text = "Mode";
			// 
			// OldBalanceTextBox
			// 
			this.OldBalanceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.OldBalanceTextBox.Location = new System.Drawing.Point(144, 87);
			this.OldBalanceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.OldBalanceTextBox.Name = "OldBalanceTextBox";
			this.OldBalanceTextBox.Size = new System.Drawing.Size(455, 29);
			this.OldBalanceTextBox.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(3, 89);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 21);
			this.label7.TabIndex = 12;
			this.label7.Text = "Old Balance";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Account Number";
			// 
			// AmountTextBox
			// 
			this.AmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.AmountTextBox.Location = new System.Drawing.Point(144, 181);
			this.AmountTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.AmountTextBox.Name = "AmountTextBox";
			this.AmountTextBox.Size = new System.Drawing.Size(455, 29);
			this.AmountTextBox.TabIndex = 17;
			// 
			// AccountNumberTextBox
			// 
			this.AccountNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.AccountNumberTextBox.Location = new System.Drawing.Point(144, 3);
			this.AccountNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.AccountNumberTextBox.Name = "AccountNumberTextBox";
			this.AccountNumberTextBox.Size = new System.Drawing.Size(455, 29);
			this.AccountNumberTextBox.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(3, 47);
			this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(135, 21);
			this.label9.TabIndex = 16;
			this.label9.Text = "Name";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 183);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(135, 21);
			this.label5.TabIndex = 8;
			this.label5.Text = "Amount";
			// 
			// ModeComboBox
			// 
			this.ModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ModeComboBox.FormattingEnabled = true;
			this.ModeComboBox.Location = new System.Drawing.Point(144, 129);
			this.ModeComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
			this.ModeComboBox.Name = "ModeComboBox";
			this.ModeComboBox.Size = new System.Drawing.Size(455, 29);
			this.ModeComboBox.TabIndex = 20;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.NameTextBox.Location = new System.Drawing.Point(144, 45);
			this.NameTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(455, 29);
			this.NameTextBox.TabIndex = 13;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel2);
			this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel3);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(71, 200);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(510, 468);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
			this.flowLayoutPanel2.Size = new System.Drawing.Size(618, 468);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.SaveButton, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.ClearAllFieldButton, 1, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 234);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(602, 56);
			this.tableLayoutPanel3.TabIndex = 2;
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(216)))));
			this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SaveButton.Location = new System.Drawing.Point(3, 3);
			this.SaveButton.MinimumSize = new System.Drawing.Size(0, 50);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(295, 50);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Withdraw";
			this.SaveButton.UseVisualStyleBackColor = false;
			// 
			// ClearAllFieldButton
			// 
			this.ClearAllFieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearAllFieldButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this.ClearAllFieldButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClearAllFieldButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClearAllFieldButton.Location = new System.Drawing.Point(304, 3);
			this.ClearAllFieldButton.MinimumSize = new System.Drawing.Size(0, 50);
			this.ClearAllFieldButton.Name = "ClearAllFieldButton";
			this.ClearAllFieldButton.Size = new System.Drawing.Size(295, 50);
			this.ClearAllFieldButton.TabIndex = 0;
			this.ClearAllFieldButton.Text = "Clear";
			this.ClearAllFieldButton.UseVisualStyleBackColor = false;
			// 
			// sample
			// 
			this.sample.HeaderText = "Column1";
			this.sample.Name = "sample";
			this.sample.ReadOnly = true;
			// 
			// label15
			// 
			this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.Color.White;
			this.label15.Location = new System.Drawing.Point(0, 5);
			this.label15.Margin = new System.Windows.Forms.Padding(0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(160, 15);
			this.label15.TabIndex = 2;
			this.label15.Text = "© Rafael Dionaldo Martinez";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.Controls.Add(this.label15, 0, 1);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 836);
			this.tableLayoutPanel5.MinimumSize = new System.Drawing.Size(1400, 25);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.Size = new System.Drawing.Size(1400, 25);
			this.tableLayoutPanel5.TabIndex = 17;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sample});
			this.dataGridView1.Location = new System.Drawing.Point(3, 54);
			this.dataGridView1.MinimumSize = new System.Drawing.Size(670, 400);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(670, 673);
			this.dataGridView1.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel6);
			this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(695, 63);
			this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(694, 519);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(694, 734);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.AutoSize = true;
			this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel6.Controls.Add(this.label13, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.textBox10, 1, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 13);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(670, 35);
			this.tableLayoutPanel6.TabIndex = 1;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 7);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(57, 21);
			this.label13.TabIndex = 0;
			this.label13.Text = "Search";
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(66, 3);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(601, 29);
			this.textBox10.TabIndex = 1;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 1, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(1384, 861);
			this.tableLayoutPanel4.TabIndex = 18;
			// 
			// AdminWithdrawForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1384, 861);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.tableLayoutPanel5);
			this.Controls.Add(this.tableLayoutPanel4);
			this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1400, 900);
			this.Name = "AdminWithdrawForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AdminWithdrawForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox OldBalanceTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox AmountTextBox;
		private System.Windows.Forms.TextBox AccountNumberTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox ModeComboBox;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button ClearAllFieldButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn sample;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
	}
}