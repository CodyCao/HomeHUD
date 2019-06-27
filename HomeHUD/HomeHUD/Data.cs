using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;
using System.IO;
using Newtonsoft.Json;

namespace HomeHUD
{
    class Data
    {
        private Dictionary<string, Profile> profiles;
        private CalendarAPI api;
        
        public Data()
        {
            profiles = ProfileConfigLoad("../../DataConfig.json");
            api = new CalendarAPI();
            SyncCalendars();
        }

        public static Dictionary<string, Profile> ProfileConfigLoad(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                Dictionary<string, Profile> jProfile = JsonConvert.DeserializeObject<Dictionary<string,Profile>>(json);
                return jProfile;
            }
        }
        public void SyncCalendars()
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
                    Console.WriteLine(k);
                    if (profiles != null && profiles.Count > 0)
                    {
                        foreach (var eventItem in profiles[k].Events.Items)
                        {
                            string when = eventItem.Start.DateTime.ToString();
                            
                            if (String.IsNullOrEmpty(when))
                            {
                                when = eventItem.Start.Date.ToString();
                            }
                            else
                            {
                                when = eventItem.Start.DateTime.ToString() + " - " + eventItem.End.DateTime.ToString();
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
