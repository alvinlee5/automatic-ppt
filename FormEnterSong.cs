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
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string songLyrics = textBoxLyrics.Text;
            string songTitle = textBoxTitle.Text;
            string songArtist = textBoxArtist.Text;
            m_dbManager.Add(songTitle, songArtist, songLyrics);
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxLyrics_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
