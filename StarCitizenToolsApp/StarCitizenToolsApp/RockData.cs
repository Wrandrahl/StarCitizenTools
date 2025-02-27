using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCitizenToolsApp
{
    public class RockData
    {
        public string Name { get; set; }
        public int M1 { get; set; }
        public int M2 { get; set; }
        public int M3 { get; set; }
        public int M4 { get; set; }
        public int M5 { get; set; }
        public int M6 { get; set; }
        public int M7 { get; set; }
        public int M8 { get; set; }
        public int M9 { get; set; }
        public int M10 { get; set; }
        public int M11 { get; set; }

        public RockData(string name, int baseValue)
        {
            Name = name;
            M1 = baseValue * 1;
            M2 = baseValue * 2;
            M3 = baseValue * 3;
            M4 = baseValue * 4;
            M5 = baseValue * 5;
            M6 = baseValue * 6;
            M7 = baseValue * 7;
            M8 = baseValue * 8;
            M9 = baseValue * 9;
            M10 = baseValue * 10;
            M11 = baseValue * 11;
        }
    }
}
