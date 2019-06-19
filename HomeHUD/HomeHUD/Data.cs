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
        private Dictionary<string,Events> events;
        private CalendarAPI cAPI;

        public Data(string initCalendarID)
        {
            cAPI = new CalendarAPI();
            events = new Dictionary<string, Events>()
            {
                { "lhrt0f53jorerki95thp3ag6cg@group.calendar.google.com", cAPI.GetCalendar("lhrt0f53jorerki95thp3ag6cg@group.calendar.google.com")}
            };

        }

        public void updateCalendars()
        {
            if(events != null && events.Count > 0)
            {
                var keys = new List<string>(events.Keys);
                foreach(var k in keys)
                {
                    events[k] = cAPI.GetCalendar(k);
                }
            }
            else
            {
                Console.WriteLine("No Avaliable Calendars to Update.");
            }

        }
    }
}
