using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace iis_web.Models
{
    [XmlRoot(ElementName = "character")]
    public class Character
    {
        public enum CharacterStatus
        {
            ALIVE,
            DEAD,
            UNKNOWN
        }

        public enum CharacterGender
        {
            UNKNOWN,
            FEMALE,
            MALE,
            GENDERLESS
        }

        [XmlIgnore]
        [XmlAttribute(AttributeName = "id")]
        public int ID { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "species")]
        public string Species { get; set; }

        [XmlElement(ElementName = "gender")]
        public string Gender { get; set; }

        [XmlElement(ElementName = "origin")]
        public Location Origin { get; set; }

        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }

        [XmlElement(ElementName = "image")]
        public string Image { get; set; }

        [XmlElement(ElementName = "episodes")]
        public Episodes Episodes { get; set; }
    }
}