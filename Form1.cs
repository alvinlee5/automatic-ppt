using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace AutoPoint
{
    public partial class Form1 : Form
    {
        private DatabaseManager m_dbManager;
        private PowerPointManager m_powerPointManager;
        public Form1()
        {
            InitializeComponent();
            m_dbManager = new DatabaseManager();
            m_powerPointManager = new PowerPointManager(m_dbManager);
            songListBox.SelectionMode = SelectionMode.None;
            m_dbManager.FillListBox(songListBox, "");
            songListBox.SelectionMode = SelectionMode.One;
            searchTextBox.Text = "Search Song List";
            searchTextBox.ForeColor = Color.Gray;
        }
        private void buttonRemoveSelectedSong_Click(object sender, System.EventArgs e)
        {
            int currentIndex = selectedSongsListBox.SelectedIndex;
            selectedSongsListBox.Items.Remove(selectedSongsListBox.SelectedItem); 
            if (selectedSongsListBox.Items.Count > 0)
            {
                if (currentIndex == selectedSongsListBox.Items.Count)
                {
                    selectedSongsListBox.SelectedIndex = selectedSongsListBox.Items.Count - 1;
                }
                else
                {
                    selectedSongsListBox.SelectedIndex = currentIndex;
                }
            }
        }

        private void buttonPublish_Click(object sender, System.EventArgs e)
        {
            if (selectedSongsListBox.Items.Count > 0)
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "PowerPoint Presentation (*.pptx)|*.pptx";
                    dialog.RestoreDirectory = true;
                    dialog.FileName = "Presentation";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        m_powerPointManager.AddSongsToPowerPoint(selectedSongsListBox.Items);
                        m_powerPointManager.SavePowerPoint(dialog.FileName);
                    }
                }
            }
            else
            {
                string message = "Choose at least 1 song!";
                // Show message box
                MessageBox.Show(message);
                return;
            }
        }

        private void buttonAddNewSong_Click(object sender, System.EventArgs e)
        {
            using (FormEnterSong formEnterSong = new FormEnterSong(m_dbManager))
            {
                formEnterSong.FormClosed += new FormClosedEventHandler(FormEnterSong_FormClosed);
                formEnterSong.ShowDialog();
            }
        }

        private void selectedSongsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedSongsListBox.SelectedIndex != -1)
            {
                buttomRemoveSelectedSong.Enabled = true;
            }
            else
            {
                buttomRemoveSelectedSong.Enabled = false;
            }
        }
        private void buttonEditSongList_Click(object sender, System.EventArgs e)
        {
            using (FormEditSongList formEditSongList = new FormEditSongList(m_dbManager))
            {
                formEditSongList.FormClosed += new FormClosedEventHandler(FormEditSongList_FormClosed);
                formEditSongList.ShowDialog();
            }                
        }

        void FormEditSongList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (searchTextBox.Text == "Search Song List" && searchTextBox.ForeColor == Color.Gray)
            {
                m_dbManager.FillListBox(songListBox, "");
            }
            else
            {
                m_dbManager.FillListBox(songListBox, searchTextBox.Text);
            }
            List<ListBoxItem> songList = new List<ListBoxItem>();
            foreach (ListBoxItem listBoxItem in selectedSongsListBox.Items)
            {
                if (!m_dbManager.IsSongInDB((listBoxItem).ValueMember))
                {
                    songList.Add(listBoxItem);
                }
            }

            foreach (var item in songList)
            {
                selectedSongsListBox.Items.Remove(item);
            }
        }

        void FormEnterSong_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (searchTextBox.Text == "Search Song List" && searchTextBox.ForeColor == Color.Gray)
            {
                m_dbManager.FillListBox(songListBox, "");
            }
            else
            {
                m_dbManager.FillListBox(songListBox, searchTextBox.Text);
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "Search Song List")
            {
                m_dbManager.FillListBox(songListBox, searchTextBox.Text);
            }
        }

        private void textBoxSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = "Search Song List";
                searchTextBox.ForeColor = Color.Gray;
            }

        }

        private void textBoxSearch_GotFocus(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Search Song List" && searchTextBox.ForeColor == Color.Gray)
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = Color.Black;
            }
        }

        private void songListBox_OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.songListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string displayMember = songListBox.GetItemText(songListBox.SelectedItem);
                string valueMember = Convert.ToString(songListBox.SelectedValue);
                selectedSongsListBox.Items.Add(new ListBoxItem(displayMember, valueMember));
            }
        }
    }
}
