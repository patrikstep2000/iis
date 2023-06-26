using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace iis_web.Models
{
    [XmlRoot("episodes")]
    public class Episodes
    {
        [XmlElement("episode")]
        public List<Episode> EpisodesList { get; set; }
    }
}