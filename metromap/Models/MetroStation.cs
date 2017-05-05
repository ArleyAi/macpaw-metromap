using System;
using System.Collections.Generic;

namespace MetroMap.Models
{
    [Serializable]
    public class MetroStation
    {
        public int Index { get; set; }

        public string Title { get; set; }

        public int TimeToNext { get; set; }

        public List<Passage> Passages { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }

    public class Passage
    {
        public int StationIndex  { get; set; }

        public int LineIndex  { get; set; }

        public int Time { get; set; }
    }
}
