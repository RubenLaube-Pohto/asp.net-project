using System;
using Microsoft.AspNetCore.Hosting;

namespace ChatApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>() // <Startup> tells to look for Startup class in Startup.cs
                .UseContentRoot(System.IO.Directory.GetCurrentDirectory())
                .Build();

            host.Run();
        }
    }
}
