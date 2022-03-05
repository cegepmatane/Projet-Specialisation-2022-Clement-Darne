using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public class Note
    {
        public Note()
        {

        }

        public int Points 
        { 
            get { return _points; } 
            set { _points = value; }
        }

        public int Max 
        { 
            get { return _max; }
            set { _max = value; }
        }

        // Stocké en millièmes de points.
        public int Coefficient { get; set; } = 1000;

        public string Description { get; set; } = "";


        // Stockés en millièmes de points.
        private int _points;
        private int _max;
    }
}
