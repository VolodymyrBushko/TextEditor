using System;
using System.Windows.Forms;

namespace VolodWF
{
    public partial class Form2 : Form
    {
        private int count;
        private string[] words;

        public Form2(RichTextBox richTextBox)
        {
            InitializeComponent();
            words = richTextBox.Text.Split('\n');
            count = 0;
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox.Text))
            {
                foreach (string word in words)
                {
                    count++;
                    if (word.Contains(richTextBox.Text))
                    {
                        listBox1.Items.Add($"On row: {count}");
                    }
                }
            }
        }
    }
}