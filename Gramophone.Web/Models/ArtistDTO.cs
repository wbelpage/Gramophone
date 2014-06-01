using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Gramophone.Web.Models
{
    public class ArtistDTO
    {
        [XmlElement(ElementName = "ArtistID")]
        public int? ArtistID { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "IsSinger")]
        public bool IsSinger { get; set; }
        [XmlElement(ElementName = "IsComposer")]
        public bool IsComposer { get; set; }
        [XmlElement(ElementName = "IsMusician")]
        public bool IsMusician { get; set; }
        [XmlElement(ElementName = "WikiLink")]
        public string WikiLink { get; set; }
        [XmlElement(ElementName = "Biography")]
        public string Biography { get; set; }
        [XmlElement(ElementName = "Photo")]
        public string Photo { get; set; }
        [XmlElement(ElementName = "WebsiteURL")]
        public string WebsiteURL { get; set; }
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
    }
}