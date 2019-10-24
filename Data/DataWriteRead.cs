using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Data
{
    public class DataWriteRead
    {
        public string Path { get; set; }
        public void readURL(string url)
        {
            var path = @"C:\Users\mathi\OneDrive\Dokument\GitHub\CsharpProjekt\podcastXML.xml";
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, path);

            Path = path;
        }

        public string returnPath()
        {


            return Path;
        }

        public void savePodcasts(string podcasts)
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (var sw = new StreamWriter("file.Json"))
            {
                using (var jtw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jtw, podcasts);
                }
            }
        }

        public string GetDataFromJson()
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (var sr = new StreamReader("file.Json"))
            {
                using (var jtr = new JsonTextReader(sr))
                {
                    string str = serializer.Deserialize<string>(jtr);
                    return str;
                }
            }
            
        }

        public string returnFilePath()
        {
            string path = @"C:\Users\mathi\OneDrive\Dokument\GitHub\CsharpProjekt\CsharpProjekt\bin\Debug";
            return path;
        }




    }
}
