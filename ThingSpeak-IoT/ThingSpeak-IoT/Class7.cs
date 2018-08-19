using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;

namespace ThingSpeak_IoT
{
    [DisplayName("Get Status")]
    [Description("Read the status field of a ThingSpeak channel.")]
    public class Activity7 : CodeActivity
    {
        
        [Category("Channel Details")]
        [RequiredArgument]
        [Description("Enter the channel ID for the ThingSpeak channel.")]
        public InArgument<string> Channel__ID { get; set; }

        [Category("Channel Details")]
        [Description("Enter the read API key for the ThingSpeak channel. You can leave this blank if you are writing to a public channel")]
        public InArgument<string> Read_API_Key { get; set; }

        public enum formatType { json, xml, csv }
        [Category("Input")]
        [RequiredArgument]
        [Description("Choose a return format type")]
        public formatType Format { get; set; }

        [Category("Output")]
        [RequiredArgument]
        [Description("Enter/create a variable to hold the retrieved value in the chosen format as a string.If you do not have access to the channel, the response is -1.")]
        public OutArgument<string> Response { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            var chID = Channel__ID.Get(context);
            var readKey = Read_API_Key.Get(context) == null ? "" : "api_key=" + Read_API_Key.Get(context);
            var chosenFormat = Format.ToString();

            string URL = "https://api.thingspeak.com/channels/" + chID + "/status." + chosenFormat + "?";
            URL = URL + readKey;

            WebRequest wrGETURL = WebRequest.Create(URL);
            Stream objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            string httpResponse = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    httpResponse = httpResponse + sLine + "\n";
            }

            Response.Set(context, httpResponse);
        }
    }
}
