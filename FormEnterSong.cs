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
        private DatabaseManager m_dbManager;
        public FormEnterSong(DatabaseManager dbManager)
        {
            InitializeComponent();
            m_dbManager = dbManager;
            textBoxLyrics.Text = "Lyrics";
            textBoxLyrics.ForeColor = Color.Gray;
            textBoxArtist.Text = "Artist";
            textBoxArtist.ForeColor = Color.Gray;
            textBoxTitle.Text = "Title";
            textBoxTitle.ForeColor = Color.Gray;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string songLyrics = textBoxLyrics.Text;
            string songTitle = textBoxTitle.Text;
            string songArtist = textBoxArtist.Text;
            if ((songLyrics == "Lyrics" && textBoxLyrics.ForeColor == Color.Gray) || 
                (songTitle == "Title" && textBoxTitle.ForeColor == Color.Gray) ||
                string.IsNullOrWhiteSpace(songLyrics) || string.IsNullOrWhiteSpace(songTitle))
            {
                // Configure message box
                string message = "Title / Lyrics cannot be empty!";
                // Show message box
                MessageBox.Show(message);
                return;
            }
            if (songArtist == "Artist" && textBoxArtist.ForeColor == Color.Gray)
            {
                songArtist = "";
            }
            m_dbManager.Add(songTitle, songArtist, songLyrics);
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxLyrics_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLyrics.Text))
            {
                textBoxLyrics.Text = "Lyrics";
                textBoxLyrics.ForeColor = Color.Gray;
            }

        }
        private void textBoxLyrics_GotFocus(object sender, EventArgs e)
        {
            if (textBoxLyrics.Text == "Lyrics" && textBoxLyrics.ForeColor == Color.Gray)
            {
                textBoxLyrics.Text = "";
                textBoxLyrics.ForeColor = Color.Black;
            }
        }

        private void textBoxArtist_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxArtist.Text))
            {
                textBoxArtist.Text = "Artist";
                textBoxArtist.ForeColor = Color.Gray;
            }

        }
        private void textBoxArtist_GotFocus(object sender, EventArgs e)
        {
            if (textBoxArtist.Text == "Artist" && textBoxArtist.ForeColor == Color.Gray)
            {
                textBoxArtist.Text = "";
                textBoxArtist.ForeColor = Color.Black;
            }
        }

        private void textBoxTitle_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                textBoxTitle.Text = "Title";
                textBoxTitle.ForeColor = Color.Gray;
            }

        }
        private void textBoxTitle_GotFocus(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == "Title" && textBoxTitle.ForeColor == Color.Gray)
            {
                textBoxTitle.Text = "";
                textBoxTitle.ForeColor = Color.Black;
            }
        }
        private void TextBoxLyrics_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
