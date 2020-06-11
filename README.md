# ASP.NET Core File Upload

**TL;DR** : I was searching in internet for a very simple lightweight FileUpload plugin using HTML, ASP.NET Core Web API and was not able to find one. So i wrote it on my own. This is primarily for the purpose of deploying .NET packages to servers. As of now there is no good way of copying (or) deploying content to target machines securely.


## What does it do
Allows the upload of a zip file from simple HTML page to a ASP. NET Core web server using API. You can also use CURL to pose the zip file. In the server side, it unzip the file to a new folder (with a new guid) and then return the directory of the folder.

## How does it work

The frontend is a simple HTML file served from a .NET Core web server running on Kestral. The server allows serving of static files and exposes a REST endpoint written in C# .NET Core. When the user uploads a file it's stored in the "contents" folder in bin\debug.
**WordPress** and **Zendesk**. With [Handlebars templates](http://handlebarsjs.com/), you have full control over what you export.

> Before starting to publish, you must link an account in the **Publish** sub-menu.

## How to compile and Run

> Install .NET CORE SDK and runtime (3.0 or greater)
> Download the repository, build and run.


## Customizations
* In `startup.cs` i have changed the cache control settings to allow easier debugging of changes to the html content. The Cache-Control age is set to 1 second in development and 604800 for production. In case you are going to use this code in production remember to change this settings.
* In `startup.cs` serving of static files and looking up for default files is enabled. This is primarily to allow serving of HTML files and also for https://localhost:5001/ to serve index.html by default. 
* In `FileController.cs` route information is explicitly set on HTTP classes and actions. Since we are extending from ControllerBase, the auto discovery of methods and actions are not happening. So explicitly adding the Route Attribute works. 
* The methods is marked `async` , and it can be reverted if needed. There is no specific reason for why i added this.
