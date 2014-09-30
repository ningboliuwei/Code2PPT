using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Code2PPT
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			//字体下拉菜单
			InstalledFontCollection installedFontCollection = new InstalledFontCollection();
			foreach (FontFamily fontFamily in installedFontCollection.Families)
			{
				cmbFontName.Items.Add(fontFamily.Name);
			}
			cmbFontName.Text = "Consolas";//默认选中Consolas字体
			//


			//字号下拉菜单
			for (int i = 6; i < 60; i++)
			{
				cmbFontSize.Items.Add(i);
				cmbFontSize.Text = "10";//默认选中10号字
			}
			//

			//Tab空格下拉菜单
			cmbTabSpaces.Items.Add("不将Tab替换为空格");
			for (int i = 1; i <= 16; i++)
			{
				cmbTabSpaces.Items.Add(i);
				cmbTabSpaces.Text = "4";//默认一个Tab相当于4个空格
			}
			//



		}


public void ChangeFont(string fontName, int fontSize)
{
	rtxCode.SelectAll();
	rtxCode.SelectionFont = new Font(fontName, fontSize);
	rtxCode.Select(0, 0);
}

		//将Enter硬回车（段落）替换为软回车（Shift+Enter）
		public string GetChangeEnter2ShfitEnterRtf(string oldRtf)
		{
			return oldRtf.Replace("\\pard", "\\line ").Replace("\\par", "\\line ");//似乎要在\\line后加一个空格
		}

		//将Tab键替换为指定数量的空格键
		public string GetChangeTab2SpaceRtf(string oldRtf, int spaceOfTab)
		{
			string spaces = "";

			for (int i = 0; i < spaceOfTab; i++)
			{
				spaces += " ";
			}

			return oldRtf.Replace("\\tab", spaces);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbFontName.Text != "" && cmbFontSize.Text != "")
			{
				ChangeFont(cmbFontName.Text, Int32.Parse(cmbFontSize.Text));
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbFontName.Text != "" && cmbFontSize.Text != "")
			{
				ChangeFont(cmbFontName.Text, Int32.Parse(cmbFontSize.Text));
			}
		}

		private void rtxCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (ModifierKeys == Keys.Control && e.KeyCode == Keys.V)//粘贴操作
			{
				string rtf;

				rtf = Clipboard.GetData(DataFormats.Rtf).ToString();
				rtf = GetChangeEnter2ShfitEnterRtf(rtf);
				if (cmbTabSpaces.SelectedIndex != 0)
				{
					rtf = GetChangeTab2SpaceRtf(rtf, Convert.ToInt32(cmbTabSpaces.Text));
				}


				rtxCode.Rtf = rtf;
				ChangeFont(cmbFontName.Text, Int32.Parse(cmbFontSize.Text));

				Clipboard.SetData(DataFormats.Rtf, rtxCode.Rtf.Trim());
			}
			else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.C) //复制操作
			{
				Clipboard.SetData(DataFormats.Rtf, rtxCode.SelectedRtf);//将选中部分的RTF代码发送到剪贴板
			}

			e.SuppressKeyPress = true;//取消系统的按键命令
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAlwaysOnTop.Checked)
			{
				TopMost = true;
			}
			else
			{
				TopMost = false;
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			string info = "";

			info += "说明：\n\n";
			info += "    1. 本程序仅用于将代码编辑器中已格式化好的代码转换为适合放置在PPT中的格式（主要是将每行的段落回车Enter转换为换行回车Shift+Enter），本身并没有代码格式化功能。\n\n";
			info += "    2. 在代码编辑器中选中已格式化好的代码，并按Ctrl+V粘贴到文本框中即可。进行粘贴操作后会自动将全部已转换好格式的代码放入剪贴板，此时只要在PPT中通过“保留源格式”的方式粘贴即可。也可在文本框中选中需要的部分，并按Ctrl+C复制到剪贴板，再粘贴到PPT中。\n\n";
			info += "    3. 可以通过下拉菜单改变字体、字号与Tab键替换为的空格数（也可以不替换）。字体与字号可以实时改变，但空格数暂时需要在粘贴源代码到本程序前进行设置，不支持实时改变。\n\n";
			info += "    4. 粘贴后的代码的字号，似乎取决于PPT主题的设置，字号设置暂时只影响在文本框中的外观，但仍暂时保留此功能。\n\n";
			info += "    仓促之作，很不完善。若有好的建议，可联系作者邮箱 liuwei@nbu.edu.cn 。";

			MessageBox.Show(info);
		}



	}
}
