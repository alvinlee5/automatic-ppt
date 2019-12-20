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
        private string m_connectionString = "Data Source=songs.db;Version=3";

        public DatabaseManager()
        {
            SetConnection();
            CreateTable();
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
            // Create Table with 3 columns
            string createTableQuery = "create table if not exists songs (id INTEGER PRIMARY KEY, title_and_artist TEXT, lyrics TEXT)";
            ExecuteQuery(createTableQuery);
        }
        public void Add(string songTitle, string songArtist, string songLyrics)
        {
            // Add song
            songTitle = songTitle.Replace("'", "''");
            songArtist = songArtist.Replace("'", "''");
            songLyrics = songLyrics.Replace("'", "''");
            string songTitleAndArtist;
            if (String.IsNullOrEmpty(songArtist))
            {
                songTitleAndArtist = songTitle;
            }
            else
            {
                songTitleAndArtist = songTitle + " - " + songArtist;
            }
            string addSongQuery = "insert into songs (title_and_artist, lyrics) values ('" + songTitleAndArtist + "', '" + songLyrics+"')";
            ExecuteQuery(addSongQuery);
        }

        //Eventually need to add a param for ID to differentiate between songs with same names...
        public void Update(string songID, string newSongLyrics)
        {
            string updateQuery = "update songs set lyrics='" + newSongLyrics + "' where id='" + songID + "'";
            ExecuteQuery(updateQuery);
        }

        public void Delete(string songID)
        {
            Console.WriteLine(songID);
            string deleteSongQuery = "delete from songs where id='" + songID + "'";
            ExecuteQuery(deleteSongQuery);
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
                            Console.WriteLine("songID: " + rdr["id"] + "\tLyrics:\n" + rdr["lyrics"]);
                    }
                }
            }
        }

        public string GetSongLyrics(string songID)
        {
            string lyrics;
            string commandText = "select * from songs where id='" + songID + "'";
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
        public void FillListBox(ListBox listBoxSongs, string textFilter)
        {
            string commandText = "select id, title_and_artist from songs where title_and_artist like '%" + textFilter + "%' order by title_and_artist collate nocase";
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                        listBoxSongs.ValueMember = dataTable.Columns[0].ToString();
                        listBoxSongs.DisplayMember = dataTable.Columns[1].ToString();
                        listBoxSongs.DataSource = dataTable;
                    }
                }
            }
        }

        public bool IsSongInDB(string songID)
        {
            Read();
            string commandText = "select * from songs where id='" + songID + "'"; 
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }
}
