using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Gramophone.Web.Models.Services
{
    public class SongService
    {
        public void AddSong(SongDTO song)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\Git\\Gramophone.Web\\App_Data\\GramophoneDB.mdf;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand cmd=connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_AddNewSong";
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);
                    cmd.Parameters.AddWithValue("@Singer1ID", song.Singer1);
                    cmd.Parameters.AddWithValue("@Singer2ID", song.Singer2);
                    cmd.Parameters.AddWithValue("@Singer3ID", song.Singer3);
                    cmd.Parameters.AddWithValue("@ComposerID", song.Composer);
                    cmd.Parameters.AddWithValue("@DirectorID", song.Director);
                    cmd.Parameters.AddWithValue("@MusicianID", song.Musician);
                    cmd.Parameters.AddWithValue("@AlbumID", song.Album);
                    cmd.Parameters.AddWithValue("@Year", song.Year);
                    cmd.Parameters.AddWithValue("@Lyrics", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Image", DBNull.Value);
                    cmd.Parameters.AddWithValue("@YouTubeURL",song.YouTubeURL);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<ArtistDTO> GetArtists()
        {
            List<ArtistDTO> artists = new List<ArtistDTO>();
            string connectionString = ConfigurationManager.ConnectionStrings["GramophoneDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))            
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select ArtistID,Name from [Artist]";
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ArtistDTO artist=new ArtistDTO();
                        artist.ArtistID=Convert.ToInt32(reader["ArtistID"].ToString());
                        artist.Name=reader["Name"].ToString();
                        artists.Add(artist);
                    }
                }
                connection.Close();
            }
            return artists;
        }

        public List<Album> GetAlbums()
        {
            List<Album> albums = new List<Album>();
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\Git\\Gramophone.Web\\App_Data\\GramophoneDB.mdf;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select AlbumID,AlbumName from [Album]";
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Album album = new Album();
                        album.AlbumID = Convert.ToInt32(reader["AlbumID"].ToString());
                        album.Name = reader["AlbumName"].ToString();
                        albums.Add(album);
                    }
                }
                connection.Close();
            }
            return albums;
        }
    }
}