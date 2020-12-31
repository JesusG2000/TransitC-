using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace notes.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Context { get; set; }
        public string Color { get; set; }
        public int  Height { get; set; }
        public int  Width { get; set; }
        public Vector Coords { get; set; }

    }
    public class Vector
    {
        public int Top { get; set; }
        public int Left { get; set; }
    }
}
