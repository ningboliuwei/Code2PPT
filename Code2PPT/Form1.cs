using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Code2PPT
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{


			//richTextBox1.Font = new Font(comboBox1.Text, Int32.Parse(comboBox2.Text));
			//richTextBox1
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InstalledFontCollection installedFontCollection = new InstalledFontCollection();

			foreach (FontFamily fontFamily in installedFontCollection.Families)
			{
				comboBox1.Items.Add(fontFamily.Name);
			}

			comboBox1.Text = "Consolas";


			for (int i = 6; i < 60; i++)
			{
				comboBox2.Items.Add(i);
			}

			comboBox2.Text = "20";


		}

		
		private void button1_Click_1(object sender, EventArgs e)
		{
			richTextBox1.Rtf = textBox1.Text;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox1.Text = richTextBox1.Rtf;
		}

		public void ChangeFont(string fontName, int fontSize)
		{
			richTextBox1.SelectAll();
			richTextBox1.SelectionFont = new Font(fontName, fontSize);
			richTextBox1.Select(0, 0);
		}

		public string GetChangeEnter2ShfitEnterRtf(string oldRtf)
		{
			return oldRtf.Replace("\\par", "\\line");
		}

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
			if (comboBox1.Text != "" && comboBox2.Text != "")
			{
				ChangeFont(comboBox1.Text, Int32.Parse(comboBox2.Text));
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.Text != "" && comboBox2.Text != "")
			{
				ChangeFont(comboBox1.Text, Int32.Parse(comboBox2.Text));
			}
		}

		private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
		{

			richTextBox1.Rtf = "";

			if (ModifierKeys == Keys.Control && e.KeyCode == Keys.V)//粘贴操作
			{
				string rtf = richTextBox1.Rtf;

				ChangeFont(comboBox1.Text, Int32.Parse(comboBox2.Text));
				
				rtf = GetChangeTab2SpaceRtf(rtf, Convert.ToInt32(textBox2.Text));
				rtf = GetChangeEnter2ShfitEnterRtf(rtf);

				richTextBox1.Rtf = rtf;

				Clipboard.SetData(DataFormats.Rtf, rtf);
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				TopMost = true;
			}
			else
			{
				TopMost = false;
			}
		}

		
	}
}
