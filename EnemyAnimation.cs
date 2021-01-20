using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class EnemyAnimation
    {
        public Dictionary<Point, char> schematic;
            
        public EnemyAnimation(Dictionary<Point, char> schematic)
        {
            foreach (KeyValuePair<Point, char> entry in schematic)
            {
                this.schematic.Add(entry.Key, entry.Value);

            }
            
        }

    }
}
