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
	using System.Collections;
	using System.ComponentModel.Design.Serialization;

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
			cmbFontName.Text = "Consolas"; //默认选中Consolas字体
			//

			//字号下拉菜单
			for (int i = 6; i < 60; i++)
			{
				cmbFontSize.Items.Add(i);
				cmbFontSize.Text = "10"; //默认选中10号字
			}
			//

			//Tab空格下拉菜单
			cmbTabSpaces.Items.Add("不替换");
			for (int i = 1; i <= 16; i++)
			{
				cmbTabSpaces.Items.Add(i);
				cmbTabSpaces.Text = "4"; //默认一个Tab相当于4个空格
			}
			//
		}

		public void ChangeFont(string fontName, int fontSize)
		{
			rtxCode.SelectAll();
			rtxCode.SelectionFont = new Font(fontName, fontSize);
			rtxCode.Select(0, 0);
		}

		/// <summary>
		///	将Enter硬回车（段落）替换为软回车（Shift+Enter）
		/// </summary>
		/// <param name="oldRtf"></param>
		/// <returns></returns>
		public string GetChangeEnter2ShfitEnterRtf(string oldRtf)
		{
			//似乎要在\\line后加一个空格
			return oldRtf.Replace("\\pard", "\\line").Replace("\\par", "\\line");
		}

		/// <summary>
		/// 将Tab键替换为指定数量的空格键
		/// </summary>
		/// <param name="oldRtf"></param>
		/// <param name="spaceOfTab"></param>
		/// <returns></returns>
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
			string rtf = "";

			if (ModifierKeys == Keys.Control && e.KeyCode == Keys.V) //粘贴操作
			{
				//得到剪贴板中的RTF文本（之前复制的）

				if (Clipboard.ContainsData(DataFormats.Rtf))
				{
					rtf = Clipboard.GetData(DataFormats.Rtf).ToString().Trim();
				}

				//替换掉所有的硬回车
				rtf = GetChangeEnter2ShfitEnterRtf(rtf);

				//将文本显示（仍带有Tab缩进）
				rtxCode.Rtf = rtf;

				//更改字体为程序设定字体
				ChangeFont(cmbFontName.Text, Int32.Parse(cmbFontSize.Text));

				Clipboard.SetData(DataFormats.Rtf, rtxCode.Rtf.Trim());
			}
			else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.C) //复制操作
			{
				Clipboard.SetData(DataFormats.Rtf, rtxCode.SelectedRtf); //将选中部分的RTF代码发送到剪贴板
			}
			//Tab
			else if (ModifierKeys == Keys.None && e.KeyCode == Keys.Tab)
			{
				//先得到文本框中的文本
				rtf = rtxCode.Rtf;
				rtf = this.GetChangeIndentRtf(rtf, true);
				rtxCode.Rtf = rtf;
			}
			//Shift + Tab
			else if (ModifierKeys == Keys.Shift && e.KeyCode == Keys.Tab)
			{
				//先得到文本框中的文本
				rtf = rtxCode.Rtf;
				rtf = this.GetChangeIndentRtf(rtf, false);

				rtxCode.Rtf = rtf;
			}

			//if (cmbTabSpaces.SelectedIndex != 0)
			//{
			//	//rtf = GetChangeTab2SpaceRtf(rtf, Convert.ToInt32(cmbTabSpaces.Text));
			//}

			e.SuppressKeyPress = true; //取消系统的按键命令
		}

		/// <summary>
		/// 修改文本的缩进
		/// </summary>
		/// <param name="rtf">需要修改的文本</param>
		/// <param name="increase">值为true，增加缩进。值为false，减少缩进</param>
		/// <returns>修改缩进后的文本</returns>
		private string GetChangeIndentRtf(string rtf, bool increase)
		{
			string[] rtfLines;


			int startLineNumber = 1;

			if (increase == true)
			{
				//在每行最前面加上一个缩进
				for (int i = startLineNumber; i < rtfLines.Length; i++)
				{
					rtfLines[i] = "\\tab" + rtfLines[i];
				}
			}
			else
			{

			}

			//将字符串数组重新拼接，分隔符为换行
			return string.Join("\\line", rtfLines).Trim();
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
			info +=
				"    2. 在代码编辑器中选中已格式化好的代码，并按Ctrl+V粘贴到文本框中即可。进行粘贴操作后会自动将全部已转换好格式的代码放入剪贴板，此时只要在PPT中通过“保留源格式”的方式粘贴即可。也可在文本框中选中需要的部分，并按Ctrl+C复制到剪贴板，再粘贴到PPT中。\n\n";
			info += "    3. 可以通过下拉菜单改变字体、字号与Tab键替换为的空格数（也可以不替换）。字体与字号可以实时改变，但空格数暂时需要在粘贴源代码到本程序前进行设置，不支持实时改变。\n\n";
			info += "    4. 粘贴后的代码的字号，似乎取决于PPT主题的设置，字号设置暂时只影响在文本框中的外观，但仍暂时保留此功能。\n\n";
			info += "    仓促之作，很不完善。若有好的建议，可联系作者邮箱 liuwei@nbu.edu.cn 。";

			MessageBox.Show(info);
		}

		/// <summary>
		/// 以字符串为分隔符的分割方法
		/// </summary>
		/// <param name="str"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public string[] SplitString(string str, string separator)
		{
			string tmp = str;
			Hashtable ht = new Hashtable();
			int i = 0;
			int pos = tmp.IndexOf(separator);
			while (pos != -1)
			{
				ht.Add(i, tmp.Substring(0, pos));
				tmp = tmp.Substring(pos + separator.Length);
				pos = tmp.IndexOf(separator);
				i++;
			}
			ht.Add(i, tmp);
			string[] array = new string[ht.Count];
			for (int j = 0; j < ht.Count; j++)
			{
				array[j] = ht[j].ToString();
			}

			return array;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="subString"></param>
		/// <returns></returns>
		public int SubStringCount(string str, string subString)
		{
			if (str.Contains(subString))
			{
				string strReplaced = str.Replace(subString, "");

				return (str.Length - strReplaced.Length) / subString.Length;
			}

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rtf"></param>
		/// <returns></returns>
		public string GetIndentRemoveRtf(string rtf)
		{
			int minTabCount = Int32.MaxValue;

			//以换行为分割单位
			string[] rtfLines = SplitString(rtf, "\\line");

			for (int i = 0; i < rtfLines.Length; i++)
			{
				//tongji 
				if (rtfLines[i].Trim() == "")
				{
					continue;
				}

				int currentLineTabCount = this.SubStringCount(rtfLines[i], "\\tab");

				if (currentLineTabCount < minTabCount)
				{
					minTabCount = currentLineTabCount;
				}
			}

			for (int i = 0; i < rtfLines.Length; i++)
			{
				for (int j = 0; j < minTabCount; j++)
				{
					if (rtfLines[i].Contains("\\tab"))
					{
						rtfLines[i] = rtfLines[i].Remove(rtfLines[i].IndexOf("\\tab"), 4);
					}
				}
			}
		}
	}
}