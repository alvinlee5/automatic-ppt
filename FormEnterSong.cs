using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPoint
{
    public partial class FormEnterSong : Form
    {
        private string m_songLyrics;
        private string m_songTitle;
        public FormEnterSong()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            m_songLyrics = textBoxLyrics.Text;
            m_songTitle = textBoxTitle.Text;
            Console.WriteLine("Name: " + m_songTitle + "\tLyrics: " + m_songLyrics);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Do nothing
        }

        private void TextBoxLyrics_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
