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
        private DatabaseManager m_dbManager;
        public FormEnterSong(DatabaseManager dbManager)
        {
            InitializeComponent();
            m_dbManager = dbManager;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            m_songLyrics = textBoxLyrics.Text;
            m_songTitle = textBoxTitle.Text;            
            m_dbManager.Add(m_songTitle, m_songLyrics);
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
