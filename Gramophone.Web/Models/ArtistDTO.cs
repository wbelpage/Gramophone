using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gramophone.Web.Models
{
    public class ArtistDTO
    {
        public int? ArtistID { get; set; }
        public string Name { get; set; }
        public bool IsSinger { get; set; }
        public bool IsComposer { get; set; }
        public bool IsMusician { get; set; }
        public string WikiLink { get; set; }
        public string Biography { get; set; }
        public string Photo { get; set; }
        public string WebsiteURL { get; set; }
        public string URL { get; set; }
    }
}