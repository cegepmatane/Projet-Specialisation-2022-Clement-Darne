using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public class Groupe : INotable
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
        public List<Note>? Notes { get; set; }
        public List<Groupe>? Groupes { get; set; }


        public float? Points
        {
            get
            {
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
                    Console.WriteLine(moyenne);

                    return moyenne;
                }
                else
                {
                    return null;
                }
            }
        }

        public float Max { get; set; } = 20.0f;
    }
}
