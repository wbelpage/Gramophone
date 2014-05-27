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
            using (SqlConnection connection = new SqlConnection("Data Source=CD-RANGAK;Initial Catalog=dbTest;Integrated Security =True"))
            {
                using (SqlCommand cmd=connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "";
                    cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);
                }
                
            }
        }
    }
}