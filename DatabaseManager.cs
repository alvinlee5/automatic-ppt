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
        private int a;

        // Should call on application open
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
            this.a = 5;
        }

        public void ExecuteQuery(string txtQuery)
        {
            m_dbConnection.Open();

            // Need to only create table if it doesn't exist.

            // Create Table with 2 columns
            string createTableQuery = "create table songs (name TEXT, lyrics TEXT)";
            m_dbCommand = m_dbConnection.CreateCommand();
            m_dbCommand.CommandText = createTableQuery;
            m_dbCommand.ExecuteNonQuery();

            // Add song
            string addSongCommand = "insert into songs (name, lyrics) values ('Oceans', 'You call me out upon...')";
            m_dbCommand = m_dbConnection.CreateCommand();
            m_dbCommand.CommandText = addSongCommand;
            m_dbCommand.ExecuteNonQuery();

            m_dbConnection.Close();

        }

        public void Read()
        {
            m_dbConnection.Open();
            string readQuery = "select * from songs";
            m_dbCommand = m_dbConnection.CreateCommand();
            m_dbCommand.CommandText = readQuery;
            SQLiteDataReader reader = m_dbCommand.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tLyrics: " + reader["lyrics"]);
            m_dbConnection.Close();
        }
    }
}
