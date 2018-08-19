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
    [DisplayName("Get Field Data")]
    [Description("Read data from a single field of a ThingSpeak channel.")]
    public class Activity4 : CodeActivity
    {

        [Category("Channel Details")]
        [RequiredArgument]
        [Description("Enter the channel ID for the ThingSpeak channel.")]
        public InArgument<string> Channel__ID { get; set; }

        [Category("Channel Details")]
        [Description("Enter the read API key for the ThingSpeak channel. You can leave this blank if you are writing to a public channel")]
        public InArgument<string> Read_API_Key { get; set; }

        public enum fields { field1, field2, field3, field4, field5, field6, field7, field8 }
        [Category("Input")]
        [RequiredArgument]
        [Description("Choose a field number")]
        public fields FieldNumber { get; set; }

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
        [Description("Number of entries to retrieve. The maximum number is 8,000.")]
        public InArgument<int> Results { get; set; }

        [Category("Optional Parameters")]
        [Description("Number of 24-hour periods before now to include in response. The default is 1.")]
        public InArgument<int> Days { get; set; }

        [Category("Optional Parameters")]
        [Description("Number of 60-second periods before now to include in response. The default is 1440.")]
        public InArgument<int> Minutes { get; set; }

        [Category("Optional Parameters")]
        [Description("Start date in format YYYY-MM-DD%20HH:NN:SS.")]
        public InArgument<string> Start { get; set; }

        [Category("Optional Parameters")]
        [Description("End date in format YYYY-MM-DD%20HH:NN:SS.")]
        public InArgument<string> End { get; set; }

        [Category("Optional Parameters")]
        [Description("Identifier from https://www.mathworks.com/help/thingspeak/time-zones-reference.html for this request.")]
        public InArgument<string> Timezone { get; set; }

        [Category("Optional Parameters")]
        [Description("Timezone offset that results are displayed in. Use the timezone parameter for greater accuracy.")]
        public InArgument<int> Offset { get; set; }

        [Category("Optional Parameters")]
        [Description(" Include status updates in feed by setting this field to true.")]
        public InArgument<Boolean> Status { get; set; }

        [Category("Optional Parameters")]
        [Description(" Includes metadata for a channel by setting this field to true.")]
        public InArgument<Boolean> Metadata { get; set; }

        [Category("Optional Parameters")]
        [Description(" Include status latitude,longitude and elevation in feed by setting this field to true.")]
        public InArgument<Boolean> Location { get; set; }

        [Category("Optional Parameters")]
        [Description(" Minimum value to include in response.( eg:10.50D )")]
        public InArgument<decimal> Min { get; set; }

        [Category("Optional Parameters")]
        [Description(" Maximum value to include in response.( eg:100.50D )")]
        public InArgument<decimal> Max { get; set; }

        [Category("Optional Parameters")]
        [Description(" Round to this many decimal places.")]
        public InArgument<int> Round { get; set; }

        [Category("Optional Parameters")]
        [Description(" Get first value in this many minutes, valid values: 10, 15, 20, 30, 60, 240, 720, 1440, daily")]
        public InArgument<string> Timescale { get; set; }

        [Category("Optional Parameters")]
        [Description(" Get sum of this many minutes, valid values: 10, 15, 20, 30, 60, 240, 720, 1440, daily")]
        public InArgument<string> Sum { get; set; }

        [Category("Optional Parameters")]
        [Description("Get average of this many minutes, valid values: 10, 15, 20, 30, 60, 240, 720, 1440, daily")]
        public InArgument<string> Average { get; set; }

        [Category("Optional Parameters")]
        [Description("Get median of this many minutes, valid values: 10, 15, 20, 30, 60, 240, 720, 1440, daily")]
        public InArgument<string> Median { get; set; }

        [Category("Optional Parameters")]
        [Description(" Function name to be used for JSONP cross-domain requests.")]
        public InArgument<string> Callback { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            var chID = Channel__ID.Get(context);
            var readKey = Read_API_Key.Get(context) == null ? "" : "api_key=" + Read_API_Key.Get(context);
            var chosenFormat = Format.ToString();
            var chosenField = (FieldNumber.GetHashCode() + 1).ToString();

            var results = Results.Get(context) == 0 ? "" : "&results=" + Results.Get(context).ToString();
            var days = Days.Get(context) == 0 ? "" : "&days=" + Days.Get(context).ToString();
            var minutes = Minutes.Get(context) == 0 ? "" : "&minutes=" + Minutes.Get(context).ToString();
            var start = Start.Get(context) == null ? "" : "&start=" + Start.Get(context);
            var end = End.Get(context) == null ? "" : "&end=" + End.Get(context);
            var timezone = Timezone.Get(context) == null ? "" : "&timezone=" + Timezone.Get(context);
            var offset = Offset.Get(context) == 0 ? "" : "&offset=" + Offset.Get(context).ToString();
            var status = Status.Get(context) == true ? "&status=true" : "";
            var metadata = Metadata.Get(context) == true ? "&metadata=true" : "";
            var location = Location.Get(context) == true ? "&location=true" : "";
            var min = Min.Get(context) == 0 ? "" : "&min=" + Min.Get(context).ToString();
            var max = Max.Get(context) == 0 ? "" : "&max=" + Max.Get(context).ToString();
            var round = Round.Get(context) == 0 ? "" : "&round=" + Round.Get(context).ToString();
            var timescale = Timescale.Get(context) == null ? "" : "&timescale=" + Timescale.Get(context);
            var sum = Sum.Get(context) == null ? "" : "&sum=" + Sum.Get(context);
            var average = Average.Get(context) == null ? "" : "&average=" + Average.Get(context);
            var median = Median.Get(context) == null ? "" : "&median=" + Median.Get(context);
            var callback = Callback.Get(context) == null ? "" : "&callback=" + Callback.Get(context);


            string URL = "https://api.thingspeak.com/channels/" + chID + "/fields/" + chosenField + "." + chosenFormat + "?";
            URL = URL + readKey + results + days + minutes + start + end + timezone + offset + status + metadata + location
                  + min + max + round + timescale + sum + average + median + callback;

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
