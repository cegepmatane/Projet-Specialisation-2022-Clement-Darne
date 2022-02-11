using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;


namespace Success_History.Models
{
    public class Test
    {
        public Test(string texte)
        {
            Texte = texte;
        }

        public string Texte { get; set; }

        public void Serialiser()
        {
            // Création du dossier s'il n'existe pas encore.
            if (!Directory.Exists(_cheminRepertoireJSON))
            {
                Directory.CreateDirectory(_cheminRepertoireJSON);
            }

            string stringJSON = JsonSerializer.Serialize(this);
            File.WriteAllText(_cheminRepertoireJSON + "/test.json", stringJSON);
        }

        public static Test? Deserialiser()
        {
            // Le fichier n'existe pas forcément.
            try
            {
                string stringJSON = File.ReadAllText(_cheminRepertoireJSON + "/test.json");
                return JsonSerializer.Deserialize<Test>(stringJSON);
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

        
        private static string _cheminRepertoireJSON = InitialiserCheminRepertoireJSON();
    }

}
