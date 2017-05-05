using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetroMap.Models
{
    [Serializable]
    public class MetroMap
    {
        public string City { get; set; }

        [XmlArray("Lines")]
        [XmlArrayItem("Line")]
        public List<MetroLine> Lines { get; set; }
    }
}
