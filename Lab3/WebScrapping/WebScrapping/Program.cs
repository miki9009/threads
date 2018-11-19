using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScrapping
{
    class Program
    {
        static string url1 = "https://pogoda.interia.pl/prognoza-dlugoterminowa-puck,cId,28229";
        static string url2 = "https://pogoda.interia.pl/prognoza-dlugoterminowa-rzym,cId,71939";
        static Program program;
        static void Main(string[] args)
        {
            program = new Program();
            ThreadReady += program.PrintResult;
            new Task(() =>
            {
                program.Body(url1, 0);
            }).RunSynchronously();

            new Task(() =>
            {
                program.Body(url2, 1);
            }).RunSynchronously();

            Console.ReadKey();
        }

        int threadsCompleted = 0;
        static event Action<int> ThreadReady;

        string[] city = new string[2];
        string[] temperature = new string[2];

        void OnThreadReady()
        {
            threadsCompleted++;
            ThreadReady?.Invoke(threadsCompleted);
        }

        void Body(string url, int index)
        {
            var webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.UTF8;
            var doc = webClient.Load(url);
            var elements = doc.DocumentNode.Descendants("div");
            var element = elements.FirstOrDefault(x => x.HasClass("weather-currently-temp-strict"));
            if (element != null)
            {
                temperature[index] = element.InnerText;
            }
            else
            {
                temperature[index] = "unknown";
            }

            elements = doc.DocumentNode.Descendants("h3");
            element = elements.FirstOrDefault(x => x.HasClass("weather-currently-city"));
            if (element != null)
            {
                string output = element.InnerText;
                city[index] = new string(output.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
            }
            else
            {
                city[index] = "unknown";
            }
            OnThreadReady();
        }

        void PrintResult(int index)
        {
            if (index < 2) return;
            Console.WriteLine(string.Format("Pogoda w miejscowości {0} wynosi {1}, natomiast pogoda w miejscowości {2} wynosi {3}.", 
            city[0], temperature[0], city[1], temperature[1]));

            ThreadReady -= program.PrintResult;
        }
    }
}

