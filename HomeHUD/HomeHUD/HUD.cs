using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeHUD
{
    class HUD
    {
        private Data data;
        private Thread syncThread;

        //Constructors
        public HUD()
        {
            data = new Data();
            syncThread = new Thread(SyncTimer); // States which function to run for threading
            UI();
        }

        private static void SyncTimer()
        {
            while(true)
            {
                Console.WriteLine("sleeping for 0.5 secs");
                Thread.Sleep(500);
            }
        }
        public void SyncStart()
        {
            syncThread.Start();// Starts Threading Process
        }
        public void SyncEnd()
        {
            syncThread.Join();// Ends Threading Process
        }

        private void UI()
        {
            //SyncStart();

            bool end = false;
            while (!end)
            {
                Console.WriteLine("1) Sync Calendars\n2) Display Calendars\n3) End");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                    case "1":
                        data.SyncCalendars();
                        break;
                    case "2":
                        data.DisplayCalendars();
                        break;
                    case "3":
                        end = true;
                        //SyncEnd();
                        break;
                }
            }
            

        }
    }
}
