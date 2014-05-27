using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gramophone.Web.Models
{
    public class SongDTO
    {
        public int SongID { get; set; }
        public string SongTitle { get; set; }
        public int Singer1 { get; set; }
        public int Singer2 { get; set; }
        public int Singer3 { get; set; }
        public int Composer { get; set; }
        public int Director { get; set; }
        public int Musician { get; set; }
        public int Album { get; set; }
        public int Year { get; set; }
        public string YouTubeURL { get; set; }
    }
}