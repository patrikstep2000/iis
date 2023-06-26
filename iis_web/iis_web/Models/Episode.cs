using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace iis_web.Models
{
    [XmlRoot(ElementName = "episode")]
    public class Episode
    {
        [XmlAttribute(AttributeName = "id")]
        public int ID { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlIgnore]
        [XmlElement(ElementName = "name")]
        public DateTime ShowDate { get; set; }

        [XmlIgnore]
        [XmlElement(ElementName = "episodeNumber")]
        public string EpisodeNumber { get; set; }
    }
}