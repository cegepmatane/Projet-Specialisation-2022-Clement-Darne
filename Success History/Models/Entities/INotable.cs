using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public interface INotable
    {
        public float? Points { get; }
        public float Max { get; }
        public float Coefficient { get; set; }
    }

}
