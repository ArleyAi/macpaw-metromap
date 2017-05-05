using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetroMap.Models
{
    [Serializable]
    [XmlRoot(ElementName = "Line")]
    public class MetroLine
    {
        public int Index { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        [XmlArray("Stations")]
        [XmlArrayItem("Station")]
        public List<MetroStation> Stations { get; set; }
    }
}
