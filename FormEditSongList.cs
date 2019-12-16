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
    public partial class FormEditSongList : Form
    {
        private DatabaseManager m_dbManager;
        public FormEditSongList(DatabaseManager databaseManager)
        {
            InitializeComponent();
            m_dbManager = databaseManager;
            listBoxSongs.SelectionMode = SelectionMode.None;
            m_dbManager.FillListBox(listBoxSongs, "");
            listBoxSongs.SelectionMode = SelectionMode.One;
            textBoxSearch.Text = "Search Song List";
            textBoxSearch.ForeColor = Color.Gray;
        }
        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            if (listBoxSongs.Items.Count == 0 || listBoxSongs.SelectedIndex == -1)
            {
                return;
            }

            string songID = Convert.ToString(listBoxSongs.SelectedValue);
            DataRowView rowView = listBoxSongs.SelectedItem as DataRowView;
            DataTable dt = listBoxSongs.DataSource as DataTable;

            if (listBoxSongs.Items.Count == 1)
            {
                // For last removed item, clear textBox text
                textBoxLyrics.Text = null;
            }

            m_dbManager.Delete(songID);
            if (rowView == null)
            {
                return;
            }
            dt.Rows.Remove(rowView.Row);

            UpdateLyricsTextBox();
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateLyricsTextBox();
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            if (listBoxSongs.Items.Count == 0 || listBoxSongs.SelectedIndex == -1)
            {
                return;
            }

            string songID = Convert.ToString(listBoxSongs.SelectedValue);
            string newSongLyrics = textBoxLyrics.Text;
            m_dbManager.Update(songID, newSongLyrics);
        }

        private void UpdateLyricsTextBox()
        {
            if (listBoxSongs.Items.Count == 0 || listBoxSongs.SelectedIndex == -1)
            {
                textBoxLyrics.Clear();
                return;
            }
            string songID = Convert.ToString(listBoxSongs.SelectedValue);
            string lyrics = m_dbManager.GetSongLyrics(songID);
            textBoxLyrics.Text = lyrics;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != "Search Song List")
            {
                m_dbManager.FillListBox(listBoxSongs, textBoxSearch.Text);
                UpdateLyricsTextBox();
            }
        }

        private void textBoxSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = "Search Song List";
                textBoxSearch.ForeColor = Color.Gray;
            }
                
        }

        private void textBoxSearch_GotFocus(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Search Song List")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.Black;
            }
        }
    }
}
