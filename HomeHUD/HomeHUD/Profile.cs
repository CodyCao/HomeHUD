using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;
using Newtonsoft.Json;

namespace HomeHUD
{
    class Profile
    {
        private string name;
        private string calendarID;
        private Events events;

        [JsonConstructor]
        public Profile(string name, string calendarID)
        {
            this.name = name;
            this.calendarID = calendarID;
        }
        [JsonProperty("Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [JsonProperty("CalendarAPI")]
        public string CalendarID
        {
            get { return calendarID; }
            set { calendarID = value; }
        }
        public Events Events
        {
            get { return events; }
            set { events = value; }
        }

    }
}