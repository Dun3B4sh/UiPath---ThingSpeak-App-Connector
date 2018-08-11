# UiPath---ThingSpeak-App-Connector
This is an IoT package featuring UiPath Activities to read and write data to/from channels of the IoT platform ThingSpeak.

## Description 
ThingSpeak is an open source Internet of Things (IoT) application and API to store and retrieve data from things using the HTTP protocol over the Internet or via a Local Area Network. ThingSpeak enables the creation of sensor logging applications, location tracking applications, and a social network of things with status updates as well as Iot analysis.

ThingSpeak uses channels, which are like data containers to hold all of your uploaded data.A channel is made up of fields, where each field is used to hold a certain type of data. Eg: If you are working on a weather monitoring station project , you could create a channel with fields like temperature,humidity,wind speed etc. to hold the corresponding data uploaded from these sensors.

ThingSpeak provides upto 8 fields per channel and access to a channel/field to read/write data is accomplished via HTTP requests. Also a channel may be public or private. If a channel is public then, anyone can access/read your channel data using you channel ID. However if your channel is a private one , then you need to use the channel ID as well as a unique READ API key to read data from it. Similarly to write to a channel you need the WRITE API KEY.

Given below are the 7 activties provided by this package to work with ThingSpeak channels/fields. Also links are provided to the official ThingSpeak sites which contain information about the various parameters as well as HTTP responses which you may require in order to use the activities to their full potential.

**1.Update Channel Feed**\
  This activity can be used to write/post data to the fields of a ThingSpeak channel.
  Parameters are provided to enter the field values as well as the mandatory WRITE API   KEY. Additionally there are quite a few optional parameters as well as info on the HTTP response. To gain a better understanding of these parameters as well as the response you can check the link provided below.
  <https://www.mathworks.com/help/thingspeak/writedata.html>
  
**2.Get Latest Field Entry**\
This activity can be used to used to retrieve the most recent/latest data upload to a single ThingSpeak field. Reference link provided below.
<https://www.mathworks.com/help/thingspeak/readlastfieldentry.html>

**3.Get Latest Channel Feed**\
This activity can be used to used to retrieve the most recent/latest data upload to a ThingSpeak channel. The data upload could be more 1 or more number of fields belonging to the channel.Reference link provided below.
<https://www.mathworks.com/help/thingspeak/readlastentry.html>

**4.Get Field Data**\
This activity allows you to read data from a single field of a ThingSpeak channel.Options are provided to choose the format in which you like to receive the response , namely json,xml and csv.Reference link provided below for more information.
<https://www.mathworks.com/help/thingspeak/readfield.html>

**5.Get Channel Data**\
This activity allows you to read data from all fields of a ThingSpeak channel.Options are provided to choose the format in which you like to receive the response , namely json,xml and csv.Reference link provided below for more information.
<https://www.mathworks.com/help/thingspeak/readdata.html>

**6.Get Last Status**\
This activity is used to read the last status of a channel.Reference link provided below
<https://www.mathworks.com/help/thingspeak/readlaststatus.html>

**7.Get Status**\
This activity is used to read status field of a channel.Reference link provided below
<https://www.mathworks.com/help/thingspeak/readstatus.html>

## Impact & Application
This package combines the power of two rapidly developing areas of technology; Robotic Process Automation(RPA) and Internet-of-Things(IoT). With automation applied to IoT analysis , there will be a huge impact on creating , managing and extending IoT projects and applications. With many existing UiPath activities to work with json , xml and csv data ,the data from the open IoT ThingSpeak platform can easily be applied and utilized for data analysis and machine learning studies which are also fast growing fields of study. Additionally with commercial/enetrprise editions available for both UiPath as well as ThingSpeak , there is a huge scope for large scale commercial and industrial projects involving IoT , backed and managed by RPA enabling effectively managed , scalable and robust applications/products in a wide array of fields/domains.
