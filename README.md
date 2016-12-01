# Chat client with ASP.NET

## Introduction

This project aimed to build a simple chat application with ASP.NET Core. It was to use a simple MySQL database in order to save old messages and then provide basic crud operations for manipulating the data. Development was planned to be done on an installation of Ubuntu 16.04 with Visual Code. .NET Core version was 1.0.

[Requirements for the project](http://student.labranet.jamk.fi/~salesa/iio13200/harjtyoarviointi.htm)

## Setup

For environment setup see [setup.md](./setup.md)

Run `dotnet restore` in order to restore packages. `dotnet run` runs the application. With `dotnet watch run` you can have the server running and restarting when changes have been made to the source code.

## Design Notes

- Will try to use SignalR
- Use MVC
- Use EntityFramework
- MySQL database
- Very simple UI

## Release plan

- 0.1.0
  - setup mysql database
  - basic crud of messages
- 0.2.0
  - realtime chat works

## Problems during development and other notes

- No idea how to proceed
- New tools
- Fighting with Razor forms. Not very intuitive and hard to find good documentation.
- `appsettings.json` is mainly used to hold the connection information of a MySQL database. The file is copied to output so it is available for use.
- `preserveCompilationContext` is set to `true` in order to have Razor views compiled at runtime.
- Tag helpers are used to have the server generate proper Razor forms.
- `EntityFramework` needed a MySQL connection driver. There was an official one available but I could not get it to work. I used another driver from Pomelo instead.

## Afterthoughts

## Work time tracking

| Date | Task | Time (h) |
| :---: | :---: | :---: |
| | Setup and documentation | 10 |
| | Planning | 2 |
| 16.11.2016 | Gather information. Initialize web server. | 3 |
| 28.11.2016 | Implement MVC | 4 |
| 30.11.2016 | Implement EntityFramework | 3 |
| 01.12.2016 | Work on Razor forms and implement basic create | 6 |

## Sources

[Setting up EntityFramework with MySQL](http://insidemysql.com/howto-starting-with-mysql-ef-core-provider-and-connectornet-7-0-4/)
