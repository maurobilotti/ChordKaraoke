using System;
using System.IO;
using System.Net;

namespace Karaoke2._0
{
    public class Cancion
    {
        string path = $"{Environment.CurrentDirectory}\\..\\..\\HTML";
        public Cancion(int id,string cancionString)
        {
            this.Id = id;
            var cancionSplitted = cancionString.Split('-');
            cancionString = cancionString.Replace(" ", "");
            
            this.Artista = cancionSplitted[0];
            this.Tema = cancionSplitted[1];
            this.Url = cancionSplitted[2];
            

            if (cancionSplitted.Length > 3)
            {
                for (int i = 3; i < cancionSplitted.Length; i++)
                {
                    this.Url += "-" + cancionSplitted[i];
                }
            }
            this.Display = $"{this.Artista} - {this.Tema}";
            this.FilePath = $"{path}\\{Display}.html";

            SalvarHTML();

        }

        private void SalvarHTML()
        {
            WebClient cl = new WebClient();

            if(Directory.Exists(path))
            {                
                if (!File.Exists(FilePath))
                    cl.DownloadFile(this.Url, FilePath);
            }
            
        }

        public int Id { get; set; }
        public string Artista { get; set; }
        public string Tema { get; set; }
        public string FilePath { get; set; }
        public string Display { get; set; }
        public string Url { get; set; }
    }
}