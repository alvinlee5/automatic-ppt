using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace AutoPoint
{
    class DatabaseManager
    {
        private SQLiteConnection m_dbConnection;
        private SQLiteCommand m_dbCommand;
        private SQLiteDataAdapter m_dbDataAdapter;
        private DataSet m_dataSet = new DataSet();
        private DataTable m_dataTable = new DataTable();

        private void SetConnection()
        {
            // By default, version 3 creates new DB file if it doesn't exist already (?)
            // TODO: Check existence of database and table...(?)
            m_dbConnection = new SQLiteConnection("Data Source=Songs.db;Version=3");
        }

        public void ExecuteQuery(string txtQuery)
        {

        }
    }
}
