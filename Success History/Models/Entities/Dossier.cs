using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace Success_History.Models
{
    public class Dossier : Groupe
    {
        public static Dossier Init(Groupe? groupe = null)
        {
            if (groupe == null)
                s_instance = new Dossier();
            else
                s_instance = new Dossier(groupe);

            return s_instance;
        }

        public static Dossier? Get()
        {
            return s_instance;
        }

        public void Destroy()
        {
            s_instance = null;
        }

        [JsonIgnore] 
        public string FileName { get; set; }

        [JsonIgnore]
        public string DirectoryPath { get; set; }

        public int MajorVersion { get; set; } = 0;
        public int MinorVersion { get; set; } = 0;


        private Dossier()
        {
            FileName = "notes.shist";
            DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        private Dossier(Groupe groupe)
            : base(groupe)
        {
            if (Nom == null)
                FileName = "notes.shist";
            else
                FileName = Nom + ".shist";

            DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }


        private static Dossier? s_instance = null;
    }
}
