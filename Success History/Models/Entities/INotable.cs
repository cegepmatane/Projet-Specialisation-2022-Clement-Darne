using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public interface INotable
    {
        public float? Points { get; set; }
        public float Max { get; }
        public float Coefficient { get; set; }

        public void SetChildrenParent();
        public INotable? Parent { get; set; }
    }

}
