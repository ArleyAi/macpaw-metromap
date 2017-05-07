using System.Collections.Generic;
using System.Linq;
using MetroMap.Models;

namespace MetroMap.Services
{
    /// <summary>
    /// Searches optimal route on the Metro map.
    /// </summary>
    class RouteService
    {

        /// <param name="m">Map to search in.</param>
        public RouteService(MetroMap.Models.MetroMap m)
        {
            map = m;
        }

        private MetroMap.Models.MetroMap map;

        private MetroStation targetStation;

        private List<List<MetroStation>> possibleRoutes = new List<List<MetroStation>>();

        /// <summary>
        /// Find optimal route.
        /// </summary>
        /// <param name="start">Start station.</param>
        /// <param name="target">Target station.</param>
        /// <returns>Info about found route. NULL if the route is not found.</returns>
        public RouteInfo FindRoute(MetroStation start, MetroStation target)
        {
            targetStation = target;

            //Prepating to the first go.
            var startRoute = new List<MetroStation>();
            startRoute.Add(start);

            //Finding current line.
            var currentLine = map.Lines.Where(l => l.Stations.Where(s => s == start).Any()).First();

            //First go (Warning! Recursion).
            Next(startRoute, currentLine);

            if (possibleRoutes.Count == 0)
                return null;

            var timesBuffer = new List<int>();

            //Choosing the shortest route by time (and counting time of the routes).
            foreach (var route in possibleRoutes)
            {
                //Geting time of the route.
                var time = 0;
                var passageBuffer = new List<Passage>();
                for (int i = 0; i < route.Count; i++)
                {
                    var station = route[i];

                    //Checking if station is not the last in the route and if current station and next one have passages.
                    if (i + 1 != route.Count && station.Passages.Count>0 && route[i+1].Passages.Count > 0)
                    {
                        //Checking if next station is that we have passaged to.

                        Passage passageFromNext = null; //Checking if next station passages has current station index.
                        foreach (var p in route[i + 1].Passages)
                            if (p.StationIndex == station.Index)
                                passageFromNext = p;

                        Passage passageFromCurrent = null; //Checking if this station passages has next station index.
                        foreach (var p in station.Passages)
                            if (p.StationIndex == route[i + 1].Index)
                                passageFromCurrent = p;

                        if (passageFromNext != null & passageFromCurrent != null)
                        {
                            time += passageFromCurrent.Time; //Adding passage time.
                        }
                        time += station.TimeToNext; //Just adding time to next if no passages
                    }
                    else time += station.TimeToNext; //Not to create more vars and ifs.
                }

                timesBuffer.Add(time);
            }

            var info = new RouteInfo();

            //Matching sorted timeBuffer and RouteBuffer.
            var sorted = timesBuffer.Clone();
            sorted.Sort();

            info.Route = possibleRoutes[timesBuffer.IndexOf(sorted.First())];
            info.Minutes = sorted.First();

            return info;
            
        }

        /// <summary>
        /// Recursial step on station.
        /// </summary>
        /// <param name="route">Current route.</param>
        /// <param name="line">Current line.</param>
        private void Next(List<MetroStation> route, MetroLine line)
        {
            var last = route.Last(); //Current station.

            var pos = last.Index; //Index of the current station in line.

            //If there is passages
            foreach (var passage in last.Passages)
            {
                var ln = map.Lines.First(l => l.Index == passage.LineIndex); //Get passaged to line.
                var station = ln.Stations.First(s => s.Index == passage.StationIndex); //Get passaged to station.
                if (route.Where(s => s == station).Any()) //If we have already visited passaged to station.
                    continue;
                var nr = route.Clone();
                nr.Add(station); //If we have not visited passaged to station.
                Next(nr, ln);
            }
 
            if (last == targetStation) //If we are on target station.
            {
                possibleRoutes.Add(route);
                return;
            }

            if (pos > 0 && !route.Where(s => s == line.Stations[pos - 1]).Any()) //If previous station is unvisited.
            {
                var nr = route.Clone();
                nr.Add(line.Stations[pos - 1]);
                Next(nr, line); //Going back.
            }


            if (pos + 1 < line.Stations.Count && !route.Where(s => s == line.Stations[pos + 1]).Any()) //If next station is unvisited.
            {
                var nr = route.Clone();
                nr.Add(line.Stations[pos + 1]);
                Next(nr, line);  //Going forward.
            }
            else return;

        }
    }

    /// <summary>
    /// Info about route.
    /// </summary>
    public class RouteInfo
    {
        /// <summary>
        /// The time that route is going to take.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// Route stations list.
        /// </summary>
        public List<MetroStation> Route { get; set; }
    }
}
