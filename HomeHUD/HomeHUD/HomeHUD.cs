using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace HomeHUD
{
    class HomeHUD
    {
        private Data data;
        // add any other modular functionality here

        public HomeHUD()
        {
            data = DataLoad("../../DataConfig.json");
            data.SyncCalendars();
        }

        public static Data DataLoad(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                Data jdata = JsonConvert.DeserializeObject<Data>(json);
                return jdata;
            }
        }
    }
}
