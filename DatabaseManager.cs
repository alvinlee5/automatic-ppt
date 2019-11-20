using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace AutoPoint
{
    public class DatabaseManager
    {
        private SQLiteConnection m_dbConnection;
        private SQLiteCommand m_dbCommand;
        private SQLiteDataAdapter m_dbDataAdapter;
        private DataSet m_dataSet = new DataSet();
        private DataTable m_dataTable = new DataTable();
        private ComboBox m_songDropDown;

        public DatabaseManager(ComboBox songDropDown)
        {
            m_songDropDown = songDropDown;
            SetConnection();
            CreateTable();
            FillDropDown();
        }

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
        }

        public void ExecuteQuery(string txtQuery)
        {
            m_dbConnection.Open();
            m_dbCommand = m_dbConnection.CreateCommand();
            m_dbCommand.CommandText = txtQuery;
            m_dbCommand.ExecuteNonQuery();
            m_dbConnection.Close();

        }
        public void CreateTable()
        {
            // Need to only create table if it doesn't exist.
            // Create Table with 2 columns
            string createTableQuery = "create table if not exists songs (name TEXT, lyrics TEXT)";
            ExecuteQuery(createTableQuery);
        }
        public void Add(string songTitle, string songLyrics)
        {
            // Add song
            songTitle = songTitle.Replace("'", "''");
            songLyrics = songLyrics.Replace("'", "''");
            string addSongQuery = "insert into songs (name, lyrics) values ('"+songTitle+"', '"+songLyrics+"')";
            ExecuteQuery(addSongQuery);
            FillDropDown();
        }

        // Read is special case where we don't simply call ExecuteQuery
        // We call SQLiteCommand::ExecuteReader
        public void Read()
        {
            m_dbConnection.Open();
            string readQuery = "select * from songs";
            m_dbCommand = m_dbConnection.CreateCommand();
            m_dbCommand.CommandText = readQuery;
            SQLiteDataReader reader = m_dbCommand.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tLyrics:\n" + reader["lyrics"]);
            m_dbConnection.Close();
        }

        public string GetSongLyrics(string songName)
        {
            string lyrics;
            m_dbConnection.Open();
            // TODO: Exception for when song not in database, though this should never
            // happen because user will select from a list of songs found in DB.
            string getSongQuery = "select * from songs where name='" + songName + "'"; 
            m_dbCommand = m_dbConnection.CreateCommand();
            m_dbCommand.CommandText = getSongQuery;
            SQLiteDataReader reader = m_dbCommand.ExecuteReader();
            reader.Read();
            lyrics = reader["lyrics"].ToString();
            m_dbConnection.Close();
            return lyrics;
        }
        private void FillDropDown()
        {            
            m_dbConnection.Open();
            DataTable dataTable = new DataTable();
            DataRow row = dataTable.NewRow();
            m_dbCommand = m_dbConnection.CreateCommand();
            m_dbCommand.CommandText = "select name from songs";
            // TODO: Create function for calling ExecuteReader() with
            // certain CommandText
            SQLiteDataReader reader = m_dbCommand.ExecuteReader();
            dataTable.Load(reader);
            //TODO: Default drop down item implemented in a hacky way...
            // Consider fixing later
            row["name"] = "< Select Song >";
            dataTable.Rows.InsertAt(row, 0);
            m_songDropDown.DataSource = dataTable;
            m_songDropDown.ValueMember = dataTable.Columns[0].ToString();
            m_songDropDown.DisplayMember = dataTable.Columns[0].ToString();
            m_dbConnection.Close();
        }

    }
}
