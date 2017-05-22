using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyllianWorldMaker
{
    /// <summary>
    /// Just a map in the mapmaker.
    /// Only a collection of tiles
    /// </summary>
    public class Map
    {
        public string Name { get; set; }
        public int TilesWidth { get; set; }
        public int TilesHeight { get; set; }
        public List<Layer> Layers { get; set; }

        public Map()
        {

        }
    }
}
