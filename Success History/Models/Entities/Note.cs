using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public class Note : INotable, INotifyPropertyChanged
    {
        public Note()
        {

        }

        public float? Points 
        { 
            get { return _points; } 
            set 
            { 
                _points = value;
                ((Groupe?)Parent)?.UpdatePoints();
                NotifyPropertyChanged();
            }
        }

        public float Max
        {
            get { return _max; }
            set 
            { 
                _max = value;
                NotifyPropertyChanged();
            }
        }

        public float Coefficient { get; set; } = 1.0f;

        public string Description { get; set; } = "";

        public void SetChildrenParent()
        {
        }

        [JsonIgnore]
        public INotable? Parent { get; set; } = null;


        private float? _points;
        private float _max = 20.0f;


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine("prop " + propertyName);
        }
    }
}
