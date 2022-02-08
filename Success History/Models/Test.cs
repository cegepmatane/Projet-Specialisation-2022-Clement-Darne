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
            if (!Directory.Exists("./data"))
            {
                Directory.CreateDirectory("./data");
            }

            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText("./data/test.json", jsonString);
        }

        public bool deserialize()
        {
            return false;
        }
    }

}
