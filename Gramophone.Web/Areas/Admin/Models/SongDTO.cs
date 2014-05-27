using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gramophone.Web.Areas.Admin.Models
{
    public class SongDTO
    {
        public int SongID { get; set; }
        public string SongTitle { get; set; }
        public string Singer1 { get; set; }
        public string Singer2 { get; set; }
        public string Singer3 { get; set; }
        public string Composer { get; set; }
        public string Director { get; set; }
        public string Musician { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public string YouTubeURL { get; set; }
    }
}