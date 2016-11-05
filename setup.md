# Development Environment Setup

.NET Core was installed on Ubuntu 16.04 with these instructions. The purpose was to enable development of ASP.NET applications on a linux system.

## .NET Core

```shell
# Add dotnet package feed
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
sudo apt-get update

# Install .NET Core SDK
sudo apt-get install dotnet-dev-1.0.0-preview2-003131
```

## .NET Project Startup

```shell
dotnet new
# Configure project, see sources
dotnet restore
dotnet run
```

## Visual Studio Code

Visual Studio Code was installed as an editor with it's C# extension. The editor provided good support for developing ASP.NET applications.

# Sources

- ASP.NET Getting started https://docs.asp.net/en/latest/getting-started.html
- .NET Core https://www.microsoft.com/net/core#ubuntu
- Tony Sneed: Develop and Deploy ASP.NET 5 Apps on Linux https://blog.tonysneed.com/2015/05/25/develop-and-deploy-asp-net-5-apps-on-linux/
- Visual Studio Code https://code.visualstudio.com/
