# UiPath---ThingSpeak-App-Connector
This is an IoT package featuring UiPath Activities to read and write data to/from channels of the IoT platform ThingSpeak.

## Description 
ThingSpeak is an open source Internet of Things (IoT) application and API to store and retrieve data from things using the HTTP protocol over the Internet or via a Local Area Network. ThingSpeak enables the creation of sensor logging applications, location tracking applications, and a social network of things with status updates as well as Iot analysis.

ThingSpeak uses channels, which are like data containers to hold all of your uploaded data.A channel is made up of fields, where each field is used to hold a certain type of data. Eg: If you are working on a weather monitoring station project , you could create a weather monitor channel with fields like temperature,humidity,wind speed etc. to hold the corresponding data values uploaded from these sensors.

ThingSpeak provides upto 8 fields per channel and an additonal field known as status field which is usually used to hold textual data to give additional info about the data uploaded to the fields(in the weather monitor example above if the temperature is too high the status field could be set to 'Hot'). Access to a channel/field to read/write data is accomplished via HTTP requests as ThingSpeak is based on REST API.

Additonally a channel may be public or private. If a channel is public then, anyone can access/read your channel data using you channel ID. However if your channel is a private one , then you need to use the channel ID as well as a unique READ API key to read data from it. To write to a channel you need the WRITE API KEY.

----------------------------------------------------------------------------------------------------------------------------------------

## About Activities

Given below are the 7 activties provided by this package to work with ThingSpeak channels/fields.

Also links are provided (below) to the official ThingSpeak sites which contain information about the various parameters as well as HTTP responses which you may require in order to use the activities to their full potential , especially if you are new to ThingSpeak. However I have added appropriate descriptions for every activity as well as every input within each of these activities that the user may enter when using them, so that it is most convenient for anyone , beginner or advanced. 

Also,the format of the output of almost all activites can be chosen to be as json string , xml string or csv string ;since there are existing UiPath activities like 'Deserialize Json','Deserialize XML'and 'Generate Data Table' the output can be easily converted and used as json , xml or csv files , or even as plain data tables which is especially useful for data analysis. 

Also the package is named as Connector.IoT-ThingSpeak.Activites so that if you are looking for an IoT package , searching for 'IoT' would instantly show this package in the results.

Lastly , though I have provided an exhaustive list of optional parameters under the activities just as shown on the ThingSpeak sites so that it fulfills the requirements of any user , for the most part if you are using ThingSpeak for simple IoT projects then you may be using only a few of these parametrs at any given time , so you need not bother of the other parameters.



**1.Update Channel Feed**\
  This activity can be used to write/post data to the fields of a ThingSpeak channel.
  Parameters are provided to enter the field values for each respective field as well as the mandatory WRITE API KEY. Additionally there are quite a few optional parameters like status,elevation etc. as well as info on the HTTP response.Output is a string containing text,json or xml depending on the chosen format. To gain a better understanding of the optional parameters as well as the response you can check the link provided below.\
<https://www.mathworks.com/help/thingspeak/writedata.html>
  
**2.Get Latest Field Entry**\
This activity can be used to used to retrieve the most recent/latest data upload to a single ThingSpeak field.
Requires channel ID as a mandatory input as well as READ API KEY if you want to read from a private channel. For a public channel only channel ID is the mandatory input. Optional parameters for data retrieval like location,offset etc. are provided. Output is a string containing text,json,xml or csv depending on the chosen format.Reference link provided below.\
<https://www.mathworks.com/help/thingspeak/readlastfieldentry.html>

**3.Get Latest Channel Feed**\
This activity can be used to used to retrieve the most recent/latest data upload to a ThingSpeak channel. 
The data upload could be more 1 or more number of fields belonging to the channel.Requires channel ID as a mandatory input as well as READ API KEY if you want to read from a private channel. For a public channel only channel ID is the mandatory input. Optional parameters for data retrieval like location,offset etc. are provided. Output is a string containing json,xml or csv depending on the chosen format.Reference link provided below.\
<https://www.mathworks.com/help/thingspeak/readlastentry.html>

**4.Get Field Data**\
This activity allows you to read data from a single field of a ThingSpeak channel.
Requires channel ID as a mandatory input as well as READ API KEY if you want to read from a private channel.For a public channel only channel ID is the mandatory input. Additionally user can choose which field to retrieve data from a drop down list . Optional parameters for data retrieval like average,callback,days etc. are provided. Output is a string containing json, xml or csv depending on the chosen format.Reference link provided below for more information.\
<https://www.mathworks.com/help/thingspeak/readfield.html>

**5.Get Channel Data**\
This activity allows you to read data from all fields of a ThingSpeak channel.
Requires channel ID as a mandatory input as well as READ API KEY if you want to read from a private channel. For a public channel only channel ID is the mandatory input. Optional parameters for data retrieval like average,callback,days etc. are provided. Output is a string containing json, xml or csv depending on the chosen format. Reference link provided below for more information.\
<https://www.mathworks.com/help/thingspeak/readdata.html>

**6.Get Last Status**\
This activity is used to read the last status of a channel.
Requires channel ID as a mandatory input as well as READ API KEY if you want to read from a private channel. For a public channel only channel ID is the mandatory input.Output is a string containing json, xml or csv depending on the chosen format. Reference link provided below for more information.\
<https://www.mathworks.com/help/thingspeak/readlaststatus.html>

**7.Get Status**\
This activity is used to read status field of a channel.
Requires channel ID as a mandatory input as well as READ API KEY if you want to read from a private channel. For a public channel only channel ID is the mandatory input.Output is a string containing json,xml or csv depending on the chosen format. Reference link provided below for more information.\
<https://www.mathworks.com/help/thingspeak/readstatus.html>

## Impact & Application
This package combines the power of two rapidly developing areas of technology; Robotic Process Automation(RPA) and Internet-of-Things(IoT). With automation applied to IoT analysis , there will be a huge impact on creating , managing and extending IoT projects and applications. With many existing UiPath activities to work with json , xml and csv data ,the data from the open IoT ThingSpeak platform can easily be applied and utilized for data analysis and machine learning studies which are also fast growing fields of study. Additionally with commercial/enetrprise editions available for both UiPath as well as ThingSpeak , there is a huge scope for large scale commercial and industrial projects involving IoT , backed and managed by RPA enabling effectively managed , scalable and robust applications/products in a wide array of fields/domains.
