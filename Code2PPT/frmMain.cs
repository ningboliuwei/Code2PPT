﻿using System;
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
			BindFontNameDropDownList();

			BindFontSizeDropDownList();

			BindTabSpacesDropDownList();
		}

		/// <summary>
		/// 绑定Tab空格数下拉菜单
		/// </summary>
		private void BindTabSpacesDropDownList()
		{
			//Tab空格下拉菜单
			cmbTabSpaces.Items.Add("不替换");
			for (int i = 1; i <= 16; i++)
			{
				cmbTabSpaces.Items.Add(i);
				cmbTabSpaces.Text = "4"; //默认一个Tab相当于4个空格
			}
			//
		}

		/// <summary>
		/// 绑字号下拉菜单
		/// </summary>
		private void BindFontSizeDropDownList()
		{
			//字号下拉菜单
			for (int i = 6; i < 60; i++)
			{
				cmbFontSize.Items.Add(i);
				cmbFontSize.Text = "10"; //默认选中10号字
			}
			//
		}

		/// <summary>
		/// 绑定字体下拉菜单
		/// </summary>
		private void BindFontNameDropDownList()
		{
			//字体下拉菜单
			InstalledFontCollection installedFontCollection = new InstalledFontCollection();
			foreach (FontFamily fontFamily in installedFontCollection.Families)
			{
				cmbFontName.Items.Add(fontFamily.Name);
			}
			cmbFontName.Text = "Consolas"; //默认选中Consolas字体
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
			//将硬回车（\\pard）替换为软回车（\\line）
			return oldRtf.Replace("\\pard", "\\line").Replace("\\par", "\\line");
		}

		/// <summary>
		/// 将Tab键替换为指定数量的空格键
		/// </summary>
		/// <param name="oldRtf"></param>
		/// <param name="spaceOfTab"></param>
		/// <returns></returns>
		public string GetTabToSpaceRtf(string oldRtf, int spaceOfTab)
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
			string plainText = "";

			

			//粘贴操作
			if (ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
			{
				//得到剪贴板中的RTF文本（之前复制的）
				try
				{
					if (Clipboard.ContainsData(DataFormats.Rtf))
					{
						rtf = Clipboard.GetData(DataFormats.Rtf).ToString();
					}

					if (Clipboard.ContainsData(DataFormats.Text))
					{
						plainText = Clipboard.GetData(DataFormats.Text).ToString();
					}
				}
				catch (Exception exception)
				{
					throw new Exception(exception.Message);
				}

			
				

				//替换掉所有的硬回车
				rtf = GetChangeEnter2ShfitEnterRtf(rtf);

				//若自动移除缩进复选框选上，自动移除多余的缩进
				if (chkAutoRemoveIndent.Checked)
				{
					rtf = GetIndentRemoveRtf(rtf, plainText);
				}

				//将文本显示（仍带有Tab缩进）
				rtxCode.Rtf = rtf;

				//更改字体为程序设定字体
				ChangeFont(cmbFontName.Text, Int32.Parse(cmbFontSize.Text));

				//if (cmbTabSpaces.SelectedIndex != 0)
				//{
				//	rtf = GetTabToSpaceRtf(rtf, Int32.Parse(cmbTabSpaces.Text));
				//}
				
				Clipboard.SetData(DataFormats.Rtf, rtf.Trim());

				//取消掉系统自带的粘贴操作
				e.SuppressKeyPress = true;

			}
			//复制操作
			else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.C)
			{
				Clipboard.SetData(DataFormats.Rtf, rtxCode.SelectedRtf);//将选中部分的RTF代码发送到剪贴板

			}
			//Tab
			else if (ModifierKeys == Keys.None && e.KeyCode == Keys.Tab)
			{
				int rowIndex;
				
				string tabString = GetRtfTabString(rtxCode.Rtf);

				//得到当前光标所在行号
				rowIndex = rtxCode.GetLineFromCharIndex(rtxCode.SelectionStart);

				//rtxCode.Select(rtxCode.GetFirstCharIndexFromLine(rowIndex), rtxCode.Lines[rowIndex].Length);

				//当有选中文本的情况下，对所有选中文本增加缩进
				if (rtxCode.SelectedText.Length != 0)
				{
					string[] selectedRtfLines = SplitString(rtxCode.SelectedRtf, "\\line");

					for (int i = 0; i < selectedRtfLines.Length; i++)
					{
						selectedRtfLines[i] = selectedRtfLines[i].Insert(selectedRtfLines[i].IndexOf(tabString), tabString);
					}

					rtxCode.SelectedRtf = string.Join("\\line", selectedRtfLines).Trim();
				}

				//else
				//{
					
				//}

				//rtxCode.SelectionStart = rtxCode.GetFirstCharIndexFromLine(rowIndex);

				//if (chkAutoRemoveIndent.Checked)
				//{
				//	rtf = GetIndentRemoveRtf(rtf, plainText);
				//}

				//rtxCode.Rtf = rtf;
				
			}
			//Shift + Tab
			else if (ModifierKeys == Keys.Shift && e.KeyCode == Keys.Tab)
			{
				//先得到文本框中的文本
				//rtf = rtxCode.Rtf;
				//rtf = this.GetChangeIndentRtf(rtf, false);

				//rtxCode.Rtf = rtf;
			}

			//取消系统的按键命令
			//e.SuppressKeyPress = true; 

			//if (cmbTabSpaces.SelectedIndex != 0)
			//{
			//	//rtf = GetChangeTab2SpaceRtf(rtf, Convert.ToInt32(cmbTabSpaces.Text));
			//}

			
		}

		/// <summary>
		/// 修改文本的缩进
		/// </summary>
		/// <param name="rtf">需要修改的文本</param>
		/// <param name="increase">值为true，增加缩进。值为false，减少缩进</param>
		/// <returns>修改缩进后的文本</returns>
		private string GetChangeIndentRtf(string rtf, bool increase)
		{
			string[] rtfLines = SplitString(rtf, "\\line");


			int startLineNumber = 1;

			if (increase == true)
			{
				//在每行最前面加上一个缩进
				//for (int i = startLineNumber; i < rtfLines.Length; i++)
				//{
				//	rtfLines[i] = "\\tab" + rtfLines[i];
				//}
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
		/// 移除所有的多余缩进
		/// </summary>
		/// <param name="rtf">RTF文本</param>
		/// <param name="plainText">纯文本</param>
		/// <returns></returns>
		public string GetIndentRemoveRtf(string rtf, string plainText)
		{
			int minTabCount = Int32.MaxValue;

			//以换行为分割单位
			string[] rtfLines = SplitString(rtf, "\\line");
			string[] plainTextLines = SplitString(plainText, "\n");
			//string[] rtfLines = SplitString(rtf, "\\line");

			string rtfTabString = "";


			rtfTabString = GetRtfTabString(rtf);

			//计算最少的缩进占的Tab数目
			for (int i = 0; i < plainTextLines.Length; i++)
			{
				//tongji 
				if (plainTextLines[i].Trim() == "")
				{
					continue;
				}

				//统计当前行的缩进Tab数
				int currentLineTabCount = 0;

				//plainText 中的Tab字符一定是 \t
				currentLineTabCount = SubStringCount(plainTextLines[i], "\t");

				if (currentLineTabCount < minTabCount)
				{
					minTabCount = currentLineTabCount;
				}
			}

			for (int i = rtfLines.Length - plainTextLines.Length; i < rtfLines.Length; i++)
			{
				for (int j = 0; j < minTabCount; j++)
				{
					if (rtfLines[i].Contains(rtfTabString))
					{
						rtfLines[i] = rtfLines[i].Remove(rtfLines[i].IndexOf(rtfTabString), rtfTabString.Length);
					}
				}
			}

			//将字符串数组重新拼接，分隔符为换行
			return string.Join("\\line", rtfLines).Trim();
		}

		/// <summary>
		/// 判断RTF中用于表示Tab键的字符串
		/// </summary>
		/// <param name="rtf">需要判断的RTF文本</param>
		/// <returns></returns>
		private string GetRtfTabString(string rtf)
		{
			string rtfTabString = "";
			
			//判断当前RTF的Tab字符
			if (rtf.Contains("\t"))
			{
				rtfTabString = "\t";
			}
			else if (rtf.Contains("\\tab"))
			{
				rtfTabString = "\\tab";
			}

			return rtfTabString;
		}

		private void rtxCode_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void rtxCode_KeyUp(object sender, KeyEventArgs e)
		{
			//当在某行按下Tab后，自动去掉所有代码的多余缩进
			if (e.Modifiers == Keys.None && e.KeyCode == Keys.Tab)
			{
				if (chkAutoRemoveIndent.Checked)
				{
					rtxCode.Rtf = GetIndentRemoveRtf(rtxCode.Rtf, rtxCode.Text);
				}
			}
		}

		private void rtxCode_TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}