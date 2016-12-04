# Chat client with ASP.NET

## Introduction

This project aimed to build a simple chat application with ASP.NET Core. It was to use a simple MySQL database in order to save old messages and then provide basic crud operations for manipulating the data. Development was planned to be done on an installation of Ubuntu 16.04 with Visual Code. .NET Core version was 1.0.1.

[Requirements for the project](http://student.labranet.jamk.fi/~salesa/iio13200/harjtyoarviointi.htm)

## Setup

For environment setup see [setup.md](./setup.md)

Run `dotnet restore` in order to restore packages. `dotnet run` runs the application. With `dotnet watch run` you can have the server running and restarting when changes have been made to the source code.

The MySQL database required was just installed locally. Only configuration needed is to check the settings in `appsettings.json`.

For just running the application the simplest way is to use Docker Compose.

## Docker Images

- [mysql](https://hub.docker.com/_/mysql/)
- [rubenlaubepohto/chatapp](https://hub.docker.com/r/rubenlaubepohto/chatapp/)

## Design Notes

- Will try to use SignalR
- Use MVC
- Use EntityFramework
- MySQL database
- Very simple UI

## Release plan

- 0.1.0 :+1:
  - setup mysql database
  - ~~basic crud of messages~~
  - basic create and delete is enough
- 0.2.0 :+1:
  - realtime chat works

## Problems during development and other notes

- No idea how to proceed
- New tools
- Fighting with Razor forms. Not very intuitive and hard to find good documentation.
- `appsettings.json` is mainly used to hold the connection information of a MySQL database. The file is copied to output so it is available for use.
- `preserveCompilationContext` is set to `true` in order to have Razor views compiled at runtime.
- Tag helpers are used to have the server generate proper Razor forms.
- `EntityFramework` needed a MySQL connection driver. There was an official one available but I could not get it to work. I used another driver from Pomelo instead.
- Hard to find material on implementing SignalR with Asp.NET Core.
- SignalR was not officially available yet in this version of Asp.NET Core. The official release is planned for version 1.2 of Core. I had to use an experimental implementation of SignalR that was available from an alternative source. SignalR 2 was used and the up coming official release uses SignalR 3 as far as I know.
- Needed to add `Views` and `appsettings.json` to publish options in order to have the files available.
- Used `dotnet publish --configuration release` to generate a release that was copied to a docker container. The database server url had to be changed to correspond to the service name of the MySQL database in the docker-compose file in order to use the app in container.
- Could use better styling to hold the input box in place instead of it jumping all the time.
- Should propably do something to handle a larger ammount of messages. This setup is good enough for demoing.

## Afterthoughts

Building a Asp.NET Core application was very educational and taught me a lot. I really liked working in a Linux environment and then have a piece of software that could run on any system, especially with Docker. Asp.NET Core 1.1 was available during development while I began work with 1.0.1. At some point I tried to upgrade but it broke things so I rolled back.

Most of the difficulties came from the fact that I had no idea how to use the framework and it's extensions as I had no previous experience with Core. I knew C# and basic Asp.NET with Visual Studio but working in a different environment was a challenge.

I started by implementing MVC and EntityFramework with MySQL database. At this time I remember spending most of my struggling with Razor forms. Basic Razor was simple but generating forms and linking them back to a controller was a bit difficult as the available documentation was not as clear as I would have needed. After implementation the app worked at this point in a RESTfullish way.

Next I began implementing SignalR in the project. It proved a bit complicated as the library is not yet officially available yet. It should be included with the 1.2 release of .NET Core. Instead, I used some kind of development version which had to be added from a source other than NuGet. After staring at a few examples and tinkering with SignalR I managed to understand how it's supposed to work: the server generates a javascript representation of the Hub class you created and then you make calls with JQuery.

Finally I wrapped things up in containers for easy deployment.

Now that I know how the technologies work I would design the software differently. In the beginning it was impossible to make good plans as I had no idea how to implement the technologies I wanted. As a result the structure is not that great and maintainable as I would like. At this time I chose to ignore refactoring my code as the time available for the project was running out.

## Work time tracking

| Date | Task | Time (h) |
| :---: | :---: | :---: |
| | Setup and documentation | 10 |
| | Planning | 2 |
| 16.11.2016 | Gather information. Initialize web server. | 3 |
| 28.11.2016 | Implement MVC | 4 |
| 30.11.2016 | Implement EntityFramework | 3 |
| 01.12.2016 | Work on Razor forms and implement basic create | 6 |
| 02.12.2016 | Update UI, implement basic delete | 6 |
| 03.12.2016 | Implementing SignalR | 6 |
| 04.12.2016 | Implement SignalR, documentation, docker setup | 8 |
| Total hours |  | 48 |

## Sources

- [Asp.NET Core on Github](https://github.com/aspnet)
- [Asp​.NET Core Docs](https://docs.microsoft.com/en-us/aspnet/core/)
- [project.json Reference](https://docs.microsoft.com/fi-fi/dotnet/articles/core/tools/project-json)
- [How to add MVC to your ASP.NET Core web application](https://jonhilton.net/2016/07/27/how-to-add-mvc-to-your-asp-net-core-web-application/)
- [Setting up EntityFramework with MySQL](http://insidemysql.com/howto-starting-with-mysql-ef-core-provider-and-connectornet-7-0-4/)
- [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [HowTo: Starting with MySQL EF Core provider and Connector/Net 7.0.4](http://insidemysql.com/howto-starting-with-mysql-ef-core-provider-and-connectornet-7-0-4/)
- [ASP.NET Core - Razor Edit Form](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_edit_form.htm)
- [Using Sessions and HttpContext in ASP.NET Core and MVC Core](http://benjii.me/2016/07/using-sessions-and-httpcontext-in-aspnetcore-and-mvc-core/)
- [Getting started with SignalR Core](https://radu-matei.github.io/blog/signalr-core/)
