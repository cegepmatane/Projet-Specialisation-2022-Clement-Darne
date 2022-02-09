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
        public Test(string text)
        {
            Text = text;
        }

        public string Text { get; set; }


        public void Serialize()
        {
            // Directory creation if it does not exist yet
            if (!Directory.Exists(_jsonDirectoryPath))
            {
                Directory.CreateDirectory(_jsonDirectoryPath);
            }

            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(_jsonDirectoryPath + "/test.json", jsonString);
        }

        public static Test? Deserialize()
        {
            try
            {
                string jsonString = File.ReadAllText(_jsonDirectoryPath + "/test.json");
                return JsonSerializer.Deserialize<Test>(jsonString);
            }
            catch (Exception)
            {
                return null;
            }
        }


        private static string SetJsonDirectoryPath()
        {
            string exeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string? directoryPath = Path.GetDirectoryName(exeFilePath);
            if (directoryPath == null)
                return "./data";
            else
                return directoryPath + "/data";
        }

        private static string _jsonDirectoryPath = SetJsonDirectoryPath();
    }

}
