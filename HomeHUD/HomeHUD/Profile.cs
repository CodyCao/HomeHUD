using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;

namespace HomeHUD
{
    class Profile
    {
        private string name;
        private string calendarID;
        private Events events;

        public Profile(string name, string calendarID)
        {
            this.name = name;
            this.calendarID = calendarID;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
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