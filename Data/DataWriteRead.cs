using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
    }
}
