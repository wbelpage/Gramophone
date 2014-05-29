using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gramophone.Web.Models.Services
{
    public class ArtistService
    {
        public void AddArtist(ArtistDTO artist)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\Git\\Gramophone.Web\\App_Data\\GramophoneDB.mdf;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_AddArtist";
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@SongTitle", artist.Name);
                    cmd.Parameters.AddWithValue("@Singer1ID", artist.IsSinger);
                    cmd.Parameters.AddWithValue("@Singer2ID", artist.IsComposer);
                    cmd.Parameters.AddWithValue("@Singer3ID", artist.IsMusician);
                    cmd.Parameters.AddWithValue("@ComposerID", artist.WikiLink);
                    cmd.Parameters.AddWithValue("@DirectorID", artist.Biography);
                    cmd.Parameters.AddWithValue("@MusicianID", artist.Photo);
                    cmd.Parameters.AddWithValue("@AlbumID", artist.WebsiteURL);
                    cmd.Parameters.AddWithValue("@Year", artist.URL);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}