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
            m_dbManager = new DatabaseManager(songDropDown);
            m_powerPointManager = new PowerPointManager(m_dbManager);
            m_powerPointManager.AddSongToPowerPoint("Oceans");
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            m_dbManager.Read();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            m_formEnterSong = new FormEnterSong(m_dbManager);
            m_formEnterSong.Show();
        }
    }
}
