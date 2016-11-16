using System;
using Microsoft.AspNetCore.Hosting;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>() // <Startup> tells to look for Startup class in Startup.cs
                .Build();

            host.Run();
        }
    }
}
