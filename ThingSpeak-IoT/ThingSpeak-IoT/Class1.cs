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
    [DisplayName("Update Channel Feed")]
    [Description("Post data to a ThingSpeak channel")]
    public class Activity1 : CodeActivity
    {

        [Category("Channel Details")]
        [RequiredArgument]
        [Description("Enter the write API key for the ThingSpeak channel.")]
        public InArgument<string> Write_API_Key { get; set; }

        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field1 { get; set; }
        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field2 { get; set; }
        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field3 { get; set; }
        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field4 { get; set; }
        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field5 { get; set; }
        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field6 { get; set; }
        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field7 { get; set; }
        [Category("Input")]
        [Description("Enter a value to be uploaded")]
        public InArgument<string> Field8 { get; set; }

        public enum formatType { text, json, xml }
        [Category("Input")]
        [RequiredArgument]
        [Description("Choose a return format type")]
        public formatType Format { get; set; }

        [Category("Optional Parameters")]
        [Description("Latitude in degrees.Eg : 25.4780D")]
        public InArgument<decimal> Lat { get; set; }

        [Category("Optional Parameters")]
        [Description("Longitude in degrees.Eg : 25.4780D")]
        public InArgument<decimal> Long { get; set; }

        [Category("Optional Parameters")]
        [Description("Elevation in metres.")]
        public InArgument<int> Elevation { get; set; }

        [Category("Optional Parameters")]
        [Description(" Status update message.")]
        public InArgument<string> Status { get; set; }

        [Category("Optional Parameters")]
        [Description(" Twitter username linked to ThingTweet.")]
        public InArgument<string> Twitter { get; set; }

        [Category("Optional Parameters")]
        [Description(" Twitter status update.")]
        public InArgument<string> Tweet { get; set; }

        [Category("Optional Parameters")]
        [Description(" Date when feed entry was created, in ISO 8601 format, for example: 2014-12-31 23:59:59. Time zones can be specified via the timezone parameter.")]
        public InArgument<string> Created_at { get; set; }

        [Category("Output")]
        [Description("Enter a variable name to store the response. More info on responses on https://www.mathworks.com/help/thingspeak/writedata.html ")]
        public OutArgument<string> Response { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            //Channel Details
            var writeKey = Write_API_Key.Get(context);

            //Field Values
            var f1 = Field1.Get(context) != null ? "&field1=" + Field1.Get(context) : "";
            var f2 = Field2.Get(context) != null ? "&field2=" + Field2.Get(context) : "";
            var f3 = Field3.Get(context) != null ? "&field3=" + Field3.Get(context) : "";
            var f4 = Field4.Get(context) != null ? "&field4=" + Field4.Get(context) : "";
            var f5 = Field5.Get(context) != null ? "&field5=" + Field5.Get(context) : "";
            var f6 = Field6.Get(context) != null ? "&field6=" + Field6.Get(context) : "";
            var f7 = Field7.Get(context) != null ? "&field7=" + Field7.Get(context) : "";
            var f8 = Field8.Get(context) != null ? "&field8=" + Field8.Get(context) : "";

            var chosenFormat = Format.GetHashCode() == 0 ? "" : "." + Format.ToString();

            //Optional Parameters
            var lat = Lat.Get(context) == 0 ? "" : "&lat=" + Lat.Get(context).ToString();
            var lon = Long.Get(context) == 0 ? "" : "&long=" + Long.Get(context).ToString();
            var elevation = Elevation.Get(context) == 0 ? "" : "&elevation=" + Elevation.Get(context).ToString();
            var status = Status.Get(context) == null ? "" : "&status=" + Status.Get(context);
            var twitter = Twitter.Get(context) == null ? "" : "&twitter=" + Twitter.Get(context);
            var tweet = Tweet.Get(context) == null ? "" : "&tweet=" + Tweet.Get(context);
            var created_at = Created_at.Get(context) == null ? "" : "&created_at=" + Created_at.Get(context);


            //Http Request URL
            string URL = "https://api.thingspeak.com/update" + chosenFormat + "?api_key=" + writeKey;
            URL = URL + f1 + f2 + f3 + f4 + f5 + f6 + f7 + f8 + lat + lon + elevation + status + twitter + tweet + created_at;

            //Creating GET Http Request  
            WebRequest wrGETURL = WebRequest.Create(URL);
            Stream objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            //Capturing the response
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
