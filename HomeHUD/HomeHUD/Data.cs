using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;

namespace HomeHUD
{
    class Data
    {
        private Dictionary<string, Profile> profiles;
        private CalendarAPI api;

        public Data()
        {
            api = new CalendarAPI();
            profiles = new Dictionary<string, Profile>()
            {
                // Replace with loading from json
                {"Cody's Calendar", new Profile("Cody's Profile", "lhrt0f53jorerki95thp3ag6cg@group.calendar.google.com")},
                {"Brenna's Calendar", new Profile("Brenna's Calendar", "brenna.carnahan@gmail.com")}
            };

            // sync calendars here
            SyncCalendar();
        }

        public void SyncCalendar()
        {
            if(profiles != null && profiles.Count > 0)
            {
                var keys = new List<string>(profiles.Keys);
                foreach(var k in keys)
                {
                    profiles[k].Events = api.GetCalendar(profiles[k].CalendarID);
                }
            }
            else
            {
                Console.WriteLine("No Avaliable Calendars to Update.");
            }
        }
        public void DisplayCalendars()
        {
            if (profiles != null && profiles.Count > 0)
            {
                var keys = new List<string>(profiles.Keys);
                foreach (var k in keys)
                {
                    if (profiles != null && profiles.Count > 0)
                    {
                        foreach (var eventItem in profiles[k].Events.Items)
                        {
                            string when = eventItem.Start.DateTime.ToString();
                            if (String.IsNullOrEmpty(when))
                            {
                                when = eventItem.Start.Date;
                            }
                            Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Events on this Calendar.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Avaliable Calendars to Update.");
            }
        }
    }
}
