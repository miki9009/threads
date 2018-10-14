using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsProj
{
    class Program
    {
        static Program instance;
        static void Main(string[] args)
        {
            instance = new Program();
            instance.Initialize();
        }

        int processEndedCount;
        int repeat = 10;
        string url = "http://4.bp.blogspot.com/-cDeYCsNL-ZQ/UozsUJ7EqfI/AAAAAAAAGSk/EtuzOVpHoS0/s1600/andy.png";

        void Initialize()
        {
            int selected = -1;
            Console.WriteLine("Initialize with: ");
            Console.WriteLine("Sequenced: 1");
            Console.WriteLine("Multithreading: 2");

            if (int.TryParse(Console.ReadLine(), out selected))
            {
                if (selected == 1)
                {
                    StartWatch();
                    for (int i = 0; i < repeat; i++)
                        DownloadSequenced(i);
                    StopWatch();
                }
                if (selected == 2)
                {
                    processEndedCount = 0;
                    StartWatch();
                    for (int i = 0; i < repeat; i++)
                        DownloadMultitasking(i);
                }
            }
        }

        void DownloadSequenced(int i)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, "img"+i + ".png");
            }
        }

        void DownloadMultitasking(int i)
        {
            new Thread(() =>
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, "img" + i + ".png");
                    processEndedCount++;
                    if (processEndedCount == repeat)
                        StopWatch();
                }
            }).Start();

        }

        Stopwatch watch;
        void StartWatch()
        {
            watch = Stopwatch.StartNew();
        }

        void StopWatch()
        {
            watch.Stop();
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds);
            Console.WriteLine("END");
            Console.WriteLine("----------------------------------------------\n");
            Initialize();

        }
    }
}
