# My Company Site
## Website ASP NET Core MVC with content editing function


MyCompany is a template for the site, just go to the /admin page, log in and change the content of the site as you need.
## Features

- Change the content of the main page and service pages using the built-in text editor
- You can add pictures to the services.
- Edit SEO meta tags, contact details. 

## We will need to install:
1 .NET Core Windows Server Hosting. https://dotnet.microsoft.com/en-us/download
After installation, run the iisreset command on the command line.

2  MS SQL server (tested on 2014 and 2019 versions)

## Connection Actions
1) On the computer, to the compiled project folder, allow access to the names IUSR and IIS_IUSRS
2) In the IIS Manager, add a site, specify the path to the project folder in the settings.
3) Add the site to C:\Windows\System32\drivers\etc\hosts after (localhost name resolution is handled within DNS itself.)
4) In the application folder in appsettings.json in ConnectionString to specify your database connection string.
5) In the application folder in appsettings.production.json check for {} brackets.
6) On the MSSQL server, add the login name IIS APPPOOL\site name and allow it to read and write the database
7) Done

### Admin login

Login: admin
Password : superpassword
## Authors

- [@ololary](https://www.github.com/Ololary)

#### 2023
