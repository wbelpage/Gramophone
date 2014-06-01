using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Gramophone.Web.Models.Utility;

namespace Gramophone.Web.Models.Services
{
    public class ArtistService
    {
        public void AddArtist(ArtistDTO artist)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GramophoneDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_AddArtist";
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@ArtistName", artist.Name);
                    cmd.Parameters.AddWithValue("@IsSinger", artist.IsSinger);
                    cmd.Parameters.AddWithValue("@IsComposer", artist.IsComposer);
                    cmd.Parameters.AddWithValue("@IsMusician", artist.IsMusician);

                    if (!string.IsNullOrWhiteSpace(artist.WikiLink))
                    cmd.Parameters.AddWithValue("@WikiLink", artist.WikiLink);
                    else
                        cmd.Parameters.AddWithValue("@WikiLink", DBNull.Value);

                    if (!string.IsNullOrWhiteSpace(artist.Biography))
                        cmd.Parameters.AddWithValue("@Biography", artist.Biography);
                    else
                        cmd.Parameters.AddWithValue("@Biography", DBNull.Value);

                    if(artist.Photo != null)
                        cmd.Parameters.AddWithValue("@Photo", artist.Photo);
                    else
                        cmd.Parameters.AddWithValue("@Photo", DBNull.Value);

                    if (!string.IsNullOrWhiteSpace(artist.WebsiteURL))
                        cmd.Parameters.AddWithValue("@WebsiteURL", artist.WebsiteURL);
                    else
                        cmd.Parameters.AddWithValue("@WebsiteURL", DBNull.Value);

                    if (!string.IsNullOrWhiteSpace(artist.URL))
                        cmd.Parameters.AddWithValue("@URL", artist.URL);
                    else
                        cmd.Parameters.AddWithValue("@URL", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public IList<ArtistDTO> GetAll()
        {
            string commandText = "Select * FROM Artist";
            DataSet dataSet = SelectEntity(commandText);
            IList<ArtistDTO> artistList = new List<ArtistDTO>();
            foreach (DataRow dr in dataSet.Tables[0].Rows)
                artistList.Add(EntityHelper.CreateEntityFromDataRow<ArtistDTO>(dr));

            return artistList;
        }

        private static DataSet SelectEntity(string commandText)
        {
            DataSet dataSet = new DataSet();
            string connectionString = ConfigurationManager.ConnectionStrings["GramophoneDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataSet);
                }
            }
            return dataSet;
        }

        public ArtistDTO GetById(int id)
        {
            string commandText = "Select * FROM Artist WHERE ArtistID=" + id;
            DataSet dataSet = SelectEntity(commandText);

            ArtistDTO artist = EntityHelper.CreateEntityFromDataRow<ArtistDTO>(dataSet.Tables[0].Rows[0]);

            return artist;
        }
    }
}