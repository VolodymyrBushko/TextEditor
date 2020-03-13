using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VolodWF.Properties;

namespace VolodWF
{
    public partial class Form1 : Form
    {
        private bool swapLanguage;
        private string defaultPath;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private ColorDialog colorDialog;
        private FontDialog fontDialog;
        private FontStyle textBold, textItalic, textStrikeout, textUnderline;

        public Form1()
        {
            InitializeComponent();
            swapLanguage = true;
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            colorDialog = new ColorDialog();
            fontDialog = new FontDialog();
            textBold = textItalic = textStrikeout = textUnderline = default;
            defaultPath = @"D:\_FILESAVEVOLODYMYRBUSHKO.txt";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            this.MainMenuStrip = menuStrip2;
            buttonLanguage.FlatAppearance.BorderSize = 0;
            buttonLanguage.FlatStyle = FlatStyle.Flat;
            this.Text = defaultPath;
        }

        private void ButtonLanguage_Click(object sender, EventArgs e)
        {
            if (swapLanguage)
            {
                menuStrip2.Visible = false;
                menuStrip1.Visible = true;
                this.MainMenuStrip = menuStrip2;
                displayText.ContextMenuStrip = contextMenuUkr;
                (sender as Button).Image = Resources.English_Flag;
                swapLanguage = false;
            }
            else
            {
                menuStrip1.Visible = false;
                menuStrip2.Visible = true;
                this.MainMenuStrip = menuStrip2;
                displayText.ContextMenuStrip = contextMenuEng;
                (sender as Button).Image = Resources.Ukraine_Flag;
                swapLanguage = true;
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    displayText.Text = reader.ReadToEnd();
                }
            }
        }

        private void NewFile(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void SaveAsFile(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(displayText.Text);
                }
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(defaultPath))
            {
                writer.Write(displayText.Text);
            }
        }

        private void CopyText(object sender, EventArgs e)
        {
            displayText.Copy();
        }

        private void InsertText(object sender, EventArgs e)
        {
            displayText.Text =
                displayText.Text.Insert(displayText.SelectionStart, Clipboard.GetText());
        }

        private void CutText(object sender, EventArgs e)
        {
            displayText.Cut();
        }

        private void LeftText(object sender, EventArgs e)
        {
            displayText.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void MiddText(object sender, EventArgs e)
        {
            displayText.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void RightText(object sender, EventArgs e)
        {
            displayText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void UndoText(object sender, EventArgs e)
        {
            displayText.Undo();
        }

        private void SelectAllText(object sender, EventArgs e)
        {
            displayText.SelectAll();
        }

        private void BackDisplayColor(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                displayText.BackColor = colorDialog.Color;
            }
        }

        private void FontDisplayColor(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                displayText.ForeColor = colorDialog.Color;
            }
        }

        private void SelectDisplayColor(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                displayText.SelectionBackColor = colorDialog.Color;
            }
        }

        private void FontGlobalProperties(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                displayText.Font = fontDialog.Font;
            }
        }

        private void CheckFontStyle(ref FontStyle style, FontStyle choose, object sender)
        {
            if (style == default)
            {
                style = choose;
                (sender as ToolStripItem).Image = Resources.check;
            }
            else
            {
                style = default;
                (sender as ToolStripItem).Image = Resources.cancel;
            }
            displayText.SelectionFont =
                new Font(displayText.SelectionFont, textBold | textItalic | textStrikeout | textUnderline);
        }

        private void SelectTextBold(object sender, EventArgs e)
        {
            CheckFontStyle(ref textBold, FontStyle.Bold, sender);
        }

        private void Zoom_Scroll(object sender, EventArgs e)
        {
            displayText.ZoomFactor = zoom.Value + 1;
        }

        private void SelectTextItalic(object sender, EventArgs e)
        {
            CheckFontStyle(ref textItalic, FontStyle.Italic, sender);
        }

        private void SelectTextStrikeout(object sender, EventArgs e)
        {
            CheckFontStyle(ref textStrikeout, FontStyle.Strikeout, sender);
        }

        private void SelectTextUnderline(object sender, EventArgs e)
        {
            CheckFontStyle(ref textUnderline, FontStyle.Underline, sender);
        }

        private void FindText(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(displayText);
            form2.ShowDialog();
        }

        private void About(object sender, EventArgs e)
        {
            MessageBox.Show("Simple text editor\n" +
                "Developer: Volodymyr Bushko.");
        }
    }
}