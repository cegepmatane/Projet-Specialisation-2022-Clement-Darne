using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public class Groupe : INotable
    {
        // Stocké en millièmes. 
        public float Coefficient { get; set; } = 1000;

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
                    float totalCoefficients = 0.0f;

                    foreach (var notable in notables)
                    {
                        float? points = notable.Points;
                        if (points != null)
                        {
                            totalPoints += notable.Coefficient * (float)points / notable.Max;
                            totalCoefficients += notable.Coefficient;
                        }
                    }

                    float moyenne = totalPoints / totalCoefficients;
                    Console.WriteLine(moyenne);
                    return moyenne;
                }
                else
                {
                    return null;
                }
            }
        }

        public float Max { get; }
    }
}
