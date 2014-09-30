namespace Code2PPT
{
	partial class frmMain
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
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbFontName = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbFontSize = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbTabSpaces = new System.Windows.Forms.ComboBox();
			this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
			this.btnHelp = new System.Windows.Forms.Button();
			this.rtxCode = new System.Windows.Forms.RichTextBox();
			this.chkAutoRemoveIndent = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.rtxCode, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 461);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.cmbFontName);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.cmbFontSize);
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.Controls.Add(this.cmbTabSpaces);
			this.flowLayoutPanel1.Controls.Add(this.chkAlwaysOnTop);
			this.flowLayoutPanel1.Controls.Add(this.chkAutoRemoveIndent);
			this.flowLayoutPanel1.Controls.Add(this.btnHelp);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(678, 29);
			this.flowLayoutPanel1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "字体";
			// 
			// cmbFontName
			// 
			this.cmbFontName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFontName.FormattingEnabled = true;
			this.cmbFontName.Location = new System.Drawing.Point(41, 3);
			this.cmbFontName.Name = "cmbFontName";
			this.cmbFontName.Size = new System.Drawing.Size(121, 25);
			this.cmbFontName.TabIndex = 0;
			this.cmbFontName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(168, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "字号";
			// 
			// cmbFontSize
			// 
			this.cmbFontSize.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFontSize.FormattingEnabled = true;
			this.cmbFontSize.Location = new System.Drawing.Point(206, 3);
			this.cmbFontSize.Name = "cmbFontSize";
			this.cmbFontSize.Size = new System.Drawing.Size(60, 25);
			this.cmbFontSize.TabIndex = 1;
			this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(272, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Tab空格数";
			// 
			// cmbTabSpaces
			// 
			this.cmbTabSpaces.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbTabSpaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTabSpaces.FormattingEnabled = true;
			this.cmbTabSpaces.Location = new System.Drawing.Point(344, 3);
			this.cmbTabSpaces.Name = "cmbTabSpaces";
			this.cmbTabSpaces.Size = new System.Drawing.Size(60, 25);
			this.cmbTabSpaces.TabIndex = 7;
			// 
			// chkAlwaysOnTop
			// 
			this.chkAlwaysOnTop.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkAlwaysOnTop.AutoSize = true;
			this.chkAlwaysOnTop.Location = new System.Drawing.Point(410, 5);
			this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
			this.chkAlwaysOnTop.Size = new System.Drawing.Size(75, 21);
			this.chkAlwaysOnTop.TabIndex = 3;
			this.chkAlwaysOnTop.Text = "始终置顶";
			this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
			this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnHelp.Location = new System.Drawing.Point(624, 5);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(20, 20);
			this.btnHelp.TabIndex = 8;
			this.btnHelp.Text = "?";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// rtxCode
			// 
			this.rtxCode.AcceptsTab = true;
			this.rtxCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxCode.Location = new System.Drawing.Point(3, 38);
			this.rtxCode.Name = "rtxCode";
			this.rtxCode.Size = new System.Drawing.Size(678, 420);
			this.rtxCode.TabIndex = 4;
			this.rtxCode.Text = "";
			this.rtxCode.WordWrap = false;
			this.rtxCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxCode_KeyDown);
			// 
			// chkAutoRemoveIndent
			// 
			this.chkAutoRemoveIndent.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkAutoRemoveIndent.AutoSize = true;
			this.chkAutoRemoveIndent.Checked = true;
			this.chkAutoRemoveIndent.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutoRemoveIndent.Location = new System.Drawing.Point(491, 5);
			this.chkAutoRemoveIndent.Name = "chkAutoRemoveIndent";
			this.chkAutoRemoveIndent.Size = new System.Drawing.Size(127, 21);
			this.chkAutoRemoveIndent.TabIndex = 9;
			this.chkAutoRemoveIndent.Text = "自动删除多余缩进 ";
			this.chkAutoRemoveIndent.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(700, 300);
			this.Name = "frmMain";
			this.Text = "Code 2 PPT";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ComboBox cmbFontName;
		private System.Windows.Forms.ComboBox cmbFontSize;
		private System.Windows.Forms.CheckBox chkAlwaysOnTop;
		private System.Windows.Forms.RichTextBox rtxCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbTabSpaces;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.CheckBox chkAutoRemoveIndent;


	}
}

