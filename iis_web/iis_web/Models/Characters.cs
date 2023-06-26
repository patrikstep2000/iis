using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace iis_web.Models
{
    [XmlRoot("characters")]
    public class Characters
    {
        [XmlElement("character")]
        public List<GetCharacter> CharactersList { get; set; }
    }
}