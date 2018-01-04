Description:  
Create a simple single page web site. It should detect visitor’s city and display current weather conditions and forecast for 10 days.  
Requirements:  
Framework:
ASP.NET Core 1.0 framework for website.  
API:  
Weather information from APIXU.   
Visitor information from Ipinfo.  
Notes:  
Write clean, readable and testable code. Adding CSS styling to website is not mandatory, but preferable. Consuming above APIs must be done server-side. Client-side javascript must not be used for that.


#### [POST /authenticate](#post-authenticate)

Generates access token for user.

Method: `POST`<br />
Versions: `1.0.0`

##### Parameters

* `email` - User's email address (`string`)
* `password` - User's password (`string`)

<br />
