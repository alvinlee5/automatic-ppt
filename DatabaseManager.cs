using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace AutoPoint
{
    class DatabaseManager
    {
        private SQLiteConnection m_dbConnection;
        private SQLiteCommand m_dbCommand;
        private SQLiteDataAdapter m_dbDataAdapter;
        private DataSet m_dataSet = new DataSet();
        private DataTable m_dataTable = new DataTable();

        //Change back to private later
        public void SetConnection()
        {
/*            if (File.Exists("songs.db"))
            {
                File.Delete("songs.db");
            }*/

            // Create DB if it doesn't exist.
            // C:\Users\Alvin\source\repos\AutoPoint\bin\Debug\songs.db
            if (!File.Exists("songs.db"))
            {
                SQLiteConnection.CreateFile("songs.db");
            }
            

            m_dbConnection = new SQLiteConnection("Data Source=songs.db;Version=3");
        }

        public void ExecuteQuery(string txtQuery)
        {

        }
    }
}
