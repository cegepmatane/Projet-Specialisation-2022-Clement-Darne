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
            if (!Directory.Exists("./data"))
            {
                Directory.CreateDirectory("./data");
            }

            // Enregistrement du fichier avec le texte de sérialisation.
            string stringJSON = JsonSerializer.Serialize(this);
            File.WriteAllText("./data/test.json", stringJSON);
        }

        public static Test? Deserialiser()
        {
            // Le fichier n'existe pas forcément.
            try
            {
                string stringJSON = File.ReadAllText("./data/test.json");
                return JsonSerializer.Deserialize<Test>(stringJSON);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }
    }

}
