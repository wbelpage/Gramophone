using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

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
                    cmd.CommandText = "";
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);
                }
                connection.Close();
            }
        }

        public List<ArtistDTO> GetArtists()
        {
            List<ArtistDTO> artists = new List<ArtistDTO>();
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\Git\\Gramophone.Web\\App_Data\\GramophoneDB.mdf;Integrated Security=True"))
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
                    cmd.CommandText = "select AlbumID,Name from [Albums]";
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Album album = new Album();
                        album.AlbumID = Convert.ToInt32(reader["AlbumID"].ToString());
                        album.Name = reader["Name"].ToString();
                        albums.Add(album);
                    }
                }
                connection.Close();
            }
            return albums;
        }
    }
}