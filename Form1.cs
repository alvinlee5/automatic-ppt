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

namespace AutoPoint
{
    public partial class Form1 : Form
    {
        private DatabaseManager m_dbManager;
        private FormEnterSong m_formEnterSong;
        private PowerPointManager m_powerPointManager;
        public Form1()
        {
            InitializeComponent();
            m_dbManager = new DatabaseManager(songComboBox);
            m_powerPointManager = new PowerPointManager(m_dbManager);
        }

        private void buttonAddSelectedSong_Click(object sender, System.EventArgs e)
        {
            if (Convert.ToInt64(songComboBox.SelectedValue) != -1)
            {
                string displayMember = songComboBox.GetItemText(songComboBox.SelectedItem);
                string valueMember = Convert.ToString(songComboBox.SelectedValue);
                selectedSongsListBox.Items.Add(new ListBoxItem(displayMember, valueMember));
            }
        }

        private void buttonRemoveSelectedSong_Click(object sender, System.EventArgs e)
        {
            selectedSongsListBox.Items.Remove(selectedSongsListBox.SelectedItem);
        }

        private void buttonPublish_Click(object sender, System.EventArgs e)
        {
            m_powerPointManager.AddSongsToPowerPoint(selectedSongsListBox.Items);
            m_powerPointManager.SavePowerPoint("C:/Users/Alvin/Desktop/sample.pptx");
        }

        private void buttonAddNewSong_Click(object sender, System.EventArgs e)
        {
            m_formEnterSong = new FormEnterSong(m_dbManager);
            m_formEnterSong.ShowDialog();
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

        private void songComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt64(songComboBox.SelectedValue) != -1)
            {
                buttonAddSelectedSong.Enabled = true;
            }
            else
            {
                buttonAddSelectedSong.Enabled = false;
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
    }
}
