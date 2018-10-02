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
    [DisplayName("Get Latest Channel Feed")]
    [Description("Get the last entry to a ThingSpeak channel.")]
    public class Activity3 : CodeActivity
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
        [Description("Enter/create a variable to hold the retrieved value in the chosen formats as a string.If you do not have access to the channel, the response is -1.")]
        public OutArgument<string> Response { get; set; }

        [Category("Optional Parameters")]
        [Description(" Identifier from https://www.mathworks.com/help/thingspeak/time-zones-reference.html for this request.")]
        public InArgument<string> Timezone { get; set; }

        [Category("Optional Parameters")]
        [Description(" Timezone offset that results are displayed in. Use the timezone parameter for greater accuracy.")]
        public InArgument<int> Offset { get; set; }

        [Category("Optional Parameters")]
        [Description(" Include status updates in feed by setting this field to true.")]
        public InArgument<Boolean> Status { get; set; }

        [Category("Optional Parameters")]
        [Description(" Include status latitude,longitude and elevation in feed by setting this field to true.")]
        public InArgument<Boolean> Location { get; set; }

        [Category("Optional Parameters")]
        [Description(" Function name to be used for JSONP cross-domain requests.")]
        public InArgument<string> Callback { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //Channel Details
            var chID = Channel__ID.Get(context);
            var readKey = Read_API_Key.Get(context) == null ? "" : "api_key=" + Read_API_Key.Get(context);
            var chosenFormat = Format.ToString();

            //Optional Parameters
            var timezone = Timezone.Get(context) == null ? "" : "&timezone=" + Timezone.Get(context);
            var offset = Offset.Get(context) == 0 ? "" : "&offset=" + Offset.Get(context).ToString();
            var status = Status.Get(context) == true ? "&status=true" : "";
            var location = Location.Get(context) == true ? "&location=true" : "";
            var callback = Callback.Get(context) == null ? "" : "&callback=" + Callback.Get(context);

            string URL = "https://api.thingspeak.com/channels/" + chID + "/feeds/" + "/last." + chosenFormat + "?";
            URL = URL + readKey + timezone + offset + status + location + callback ;

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
            objStream.Close();
            objReader.Close();
            Response.Set(context, httpResponse);
        }
    }
}
