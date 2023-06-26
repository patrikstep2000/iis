using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace iis_web.Models
{
    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlAttribute(AttributeName = "id")]
        public int ID { get; set; }

        [XmlIgnore]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlIgnore]
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlIgnore]
        [XmlElement(ElementName = "dimension")]
        public string Dimension { get; set; }
    }
}