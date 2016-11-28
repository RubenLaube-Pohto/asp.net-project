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

## Problems during development

- No idea how to proceed
- New tools

## Afterthoughts

## Work time tracking

| Date | Task | Time (h) |
| :---: | :---: | :---: |
| | Setup and documentation | 10 |
| | Planning | 2 |
| 16.11.2016 | Gather information. Initialize web server. | 3 |
