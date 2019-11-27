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
        private ComboBox m_songComboBox;
        private string m_connectionString = "Data Source=songs.db;Version=3";

        public DatabaseManager(ComboBox songComboBox)
        {
            m_songComboBox = songComboBox;
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
        }

        public void ExecuteQuery(string txtQuery)
        {
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(txtQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void CreateTable()
        {
            // Need to only create table if it doesn't exist.
            // Create Table with 2 columns
            string createTableQuery = "create table if not exists songs (id INTEGER PRIMARY KEY, name TEXT, lyrics TEXT)";
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

        //Eventually need to add a param for ID to differentiate between songs with same names...
        public void Update(string songName, string newSongLyrics)
        {
            string updateQuery = "update songs set lyrics='" + newSongLyrics + "' where name='" + songName + "'";
            ExecuteQuery(updateQuery);
        }

        public void Delete(string songName)
        {
            string deleteSongQuery = "delete from songs where name='" + songName + "'";
            ExecuteQuery(deleteSongQuery);
            FillDropDown();
        }

        // Read is special case where we don't simply call ExecuteQuery
        // We call SQLiteCommand::ExecuteReader
        public void Read()  // Function for debugging. Prints each all song name + lyrics in DB
        {
            string commandText = "select * from songs";
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                            Console.WriteLine("Name: " + rdr["name"] + "\tLyrics:\n" + rdr["lyrics"]);
                    }
                }
            }
        }

        public string GetSongLyrics(string songName)
        {
            string lyrics;
            string commandText = "select * from songs where name='" + songName + "'";
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        lyrics = rdr["lyrics"].ToString();
                        return lyrics;
                    }
                }
            }
        }
        private void FillDropDown()
        {
            string commandText = "select id, name from songs";
            DataTable dataTable = new DataTable();
            DataRow row = dataTable.NewRow();
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                        //TODO: Default drop down item implemented in a hacky way...
                        // Consider fixing later
                        row[dataTable.Columns[0].ToString()/*id*/] = -1;
                        row[dataTable.Columns[1].ToString()/*name*/] = "< Select Song >";
                        dataTable.Rows.InsertAt(row, 0);
                        m_songComboBox.DataSource = dataTable;
                        m_songComboBox.ValueMember = dataTable.Columns[0].ToString();
                        m_songComboBox.DisplayMember = dataTable.Columns[1].ToString();
                    }
                }
            }
        }

        public void FillListBox(ListBox listBoxSongs)
        {
            string commandText = "select id, name from songs";
            DataTable dataTable = new DataTable();
            DataRow row = dataTable.NewRow();
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                        listBoxSongs.DataSource = dataTable;
                        listBoxSongs.ValueMember = dataTable.Columns[0].ToString();
                        listBoxSongs.DisplayMember = dataTable.Columns[1].ToString();
                    }
                }
            }
        }
    }
}
