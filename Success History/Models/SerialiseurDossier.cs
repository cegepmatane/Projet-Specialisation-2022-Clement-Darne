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

        public void Serialiser(Groupe dossier)
        {
            // TODO: Choose file path

            // Création du dossier s'il n'existe pas encore.
            if (!Directory.Exists(_cheminRepertoireDossier))
            {
                Directory.CreateDirectory(_cheminRepertoireDossier);
            }

            string stringJSON = JsonSerializer.Serialize(dossier);
            File.WriteAllText(_cheminRepertoireDossier + "/dossier.json", stringJSON);
        }

        public Groupe? Deserialiser()
        {
            // Le fichier n'existe pas forcément.
            try
            {
                string stringJSON = File.ReadAllText(_cheminRepertoireDossier + "/dossier.json");
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

        private string _cheminRepertoireDossier = InitialiserCheminRepertoireJSON();
    }
}
