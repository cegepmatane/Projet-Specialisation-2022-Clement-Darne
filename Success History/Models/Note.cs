using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public class Note : INotable
    {
        public Note()
        {

        }

        public float? Points 
        { 
            get { return _points; } 
            set { _points = value; }
        }

        public float Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public float Coefficient { get; set; } = 1.0f;

        public string Description { get; set; } = "";


        private float? _points;
        private float _max = 20.0f;
    }
}
