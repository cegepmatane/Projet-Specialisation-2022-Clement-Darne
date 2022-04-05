using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public class Groupe : INotable, INotifyPropertyChanged
    {
        public Groupe()
        {
            
        }

        public Groupe(Groupe other)
        {
            Coefficient = other.Coefficient;
            Nom = other.Nom;
            Notes = other.Notes;
            Groupes = other.Groupes;
            Max = other.Max;
        }

        // Stocké en millièmes. 
        public float Coefficient { get; set; } = 1.0f;

        public string Nom { get; set; } = "";

        // Soit le groupe contient d'autres groupes, soit il contient des notes.
        
        private ObservableCollection<Note>? _notes;
        public ObservableCollection<Note>? Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<Groupe>? _groupes;
        public ObservableCollection<Groupe>? Groupes 
        { 
            get => _groupes;
            set
            {
                _groupes = value;
                NotifyPropertyChanged();
            }
        }


        public bool UpdatePoints()
        {
            float? oldPoints = _points;
            IEnumerable<INotable>? notables = ((Notes != null) ? Notes : Groupes);

            if (notables != null)
            {
                float totalPoints = 0.0f;
                float totalMaxs = 0.0f;
                int count = 0;

                foreach (var notable in notables)
                {
                    float? points = notable.Points;
                    if (points != null)
                    {
                        totalPoints += notable.Coefficient * (float)points / notable.Max;
                        totalMaxs += notable.Coefficient * notable.Max;
                        ++count;
                    }
                }

                float? moyenne = (count != 0) ? totalPoints * totalMaxs / (float)count / (float)count : null;
                Console.WriteLine("calc {0} : {1}" , Nom, moyenne);

                Points = moyenne;
            }
            else
            {
                Points = null;
            }

            if (_points != oldPoints)
            {
                ((Groupe?)Parent)?.UpdatePoints();
                return true;
            }
            else
            {
                return false;
            }
        }


        private float? _points;

        [JsonIgnore]
        public float? Points
        {
            get
            {
                if (_points == null)
                    UpdatePoints();
                
                return _points;
            }
            set
            {
                _points = value;
                ((Groupe?)Parent)?.UpdatePoints();
                NotifyPropertyChanged();
            }
        }

        private float _max = 20.0f;

        public float Max {
            get => _max;
            set
            {
                _max = value;
                NotifyPropertyChanged();
            }
        }


        public void SetChildrenParent()
        {
            IEnumerable<INotable>? notables = ((Notes != null) ? Notes : Groupes);

            if (notables != null)
            {
                foreach (var notable in notables)
                {
                    notable.Parent = this;
                    notable.SetChildrenParent();
                }
            }
        }

        [JsonIgnore]
        public INotable? Parent { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine("prop " + propertyName);
        }
    }
}
