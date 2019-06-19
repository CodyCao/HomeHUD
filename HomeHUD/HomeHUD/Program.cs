using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeHUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Data d = new Data("lhrt0f53jorerki95thp3ag6cg@group.calendar.google.com");
            d.updateCalendars();
        }
    }
}