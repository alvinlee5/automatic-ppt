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
            m_dbManager.FillListBox(listBoxSongs);
        }
        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            if (listBoxSongs.Items.Count == 0)
            {
                return;
            }
            string songName = listBoxSongs.GetItemText(listBoxSongs.SelectedItem);
            m_dbManager.Delete(songName);
            DataRowView rowView = listBoxSongs.SelectedItem as DataRowView;
            DataTable dt = listBoxSongs.DataSource as DataTable;
            if (rowView == null)
            {
                return;
            }
            dt.Rows.Remove(rowView.Row);
            
        }
    }
}
