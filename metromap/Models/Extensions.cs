using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMap.Models
{
    static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone)
        {
            return new List<T>(listToClone.ToList());
        }
    }
}
