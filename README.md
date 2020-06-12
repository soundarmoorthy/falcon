# Falcon

**TL;DR** : I was searching in internet for a very simple lightweight FileUpload that can  be used as deployment mechanism to deploy .NET applications and was not able to find one. This is primarily for the purpose of deploying .NET packages to servers. As of now there is no good way of copying (or) deploying content to target machines securely apart from SSH (or) proprietary software. 
**CAUTION** : 
As of now it doesn't have any security mechanism inbuilt and we are achieving that using Trusted authentication setup between servers. (Build and target). So use it with caution, and make sure it's accesible only from intranet. 


## What does it do

Allows the upload of a zip file from simple HTML page (or) a CURL command to a ASP. NET Core web server using API. In the server side, it unzip the file to a new folder (with a new guid) and then return the directory of the folder.

**NOTE**
As of now the application is configured to run as in-process from an IIS server. If you want to run it natively remove the `host.UseIIS()` statement in Program.cs

## How does it work

The frontend is a simple HTML file served from a .NET Core web server running on Kestral. The server allows serving of static files and exposes a REST endpoint written in C# .NET Core. When the user uploads a file it's stored in the "contents" folder in bin\debug (in development machine). and in <siteroot>\contents\ folder when run from a web server. 

> Before starting to publish, you must link an account in the **Publish** sub-menu.

## How to compile and Run

> Install .NET CORE SDK and runtime (3.0 or greater)
> Download the repository, build and run.

## How to see a demo

> Run the code from Visual studio (or) using dotnet command line 
> Browse to https://localhost:5001
> Follow the instructions. If you have issues with https use http instead.

### Using CURL
If you are running on Mac or Linux use the following
`curl -k -F "myFile=@/path/to/file.zip" https://localhost:5001/File/Upload`

> If you have issues with https use http instead. the -k parameter is when you have an https endpoint but the certificate validation fails. You can ignore if you have proper SSL setup.

## Customizations
* In `startup.cs` i have changed the cache control settings to allow easier debugging of changes to the html content. The Cache-Control age is set to 1 second in development and 604800 for production. In case you are going to use this code in production remember to change this settings.
* In `startup.cs` serving of static files and looking up for default files is enabled. This is primarily to allow serving of HTML files and also for https://localhost:5001/ to serve index.html by default. 
* In `FileController.cs` route information is explicitly set on HTTP classes and actions. Since we are extending from ControllerBase, the auto discovery of methods and actions are not happening. So explicitly adding the Route Attribute works. 
* The methods is marked `async` , and it can be reverted if needed. There is no specific reason for why i added this.
