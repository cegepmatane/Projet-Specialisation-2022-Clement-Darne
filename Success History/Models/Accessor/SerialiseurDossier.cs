using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Success_History.Models
{
    public class SerialiseurDossier
    {

        public static SerialiseurDossier Get()
        {
            return s_instance;
        }

        public void Serialiser(Dossier dossier)
        {
            // Création du dossier s'il n'existe pas encore.
            if (!Directory.Exists(dossier.DirectoryPath))
            {
                Directory.CreateDirectory(dossier.DirectoryPath);
            }

            string stringJSON = JsonSerializer.Serialize(dossier);
            File.WriteAllText(Path.Combine(dossier.DirectoryPath, dossier.FileName), stringJSON);
        }

        public Groupe? Deserialiser(string filePath)
        {
            // Le fichier n'existe pas forcément.
            try
            {
                string stringJSON = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Models.Groupe>(stringJSON);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        private static string InitialiserCheminRepertoireJSON()
        {
            string cheminEXE = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string? cheminRepertoire = Path.GetDirectoryName(cheminEXE);
            if (cheminRepertoire == null)
                return "./data";
            else
                return cheminRepertoire + "/data";
        }


        private static SerialiseurDossier s_instance = new SerialiseurDossier();
    }
}
