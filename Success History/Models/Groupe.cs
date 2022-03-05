using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Success_History.Models
{
    public class Groupe
    {
        // Stocké en millièmes. 
        public int Coefficient { get; set; } = 1000;

        public string Nom { get; set; } = "";

        // Soit le groupe contient d'autres groupes, soit il contient des notes.
        public List<Note>? Notes { get; set; }
        public List<Groupe>? Groupes { get; set; }
    }
}
