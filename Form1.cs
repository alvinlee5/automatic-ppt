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
            m_dbManager = new DatabaseManager();
            m_powerPointManager = new PowerPointManager(m_dbManager);
            m_dbManager.SetConnection();
            m_dbManager.CreateTable();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            m_powerPointManager.CreateSlide("title", "lyrics");
            m_powerPointManager.SavePowerPoint("C:/Users/Alvin/Desktop/sample.pptx");
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            string lyrics;
            //m_dbManager.Read();
            lyrics = m_dbManager.GetSongLyrics("Oceans");
            Console.WriteLine("Lyrics:\n" + lyrics);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            m_formEnterSong = new FormEnterSong(m_dbManager);
            m_formEnterSong.Show();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
