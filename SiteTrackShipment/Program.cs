using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SiteTrackShipment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            using (DeliveryContext db = new DeliveryContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("List of objects:");
                foreach (Users u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Email} - {u.Password}-{u.FirstName}-{u.LastName}-{u.Phone}-{u.SubscriptionStatus}-{u.IdRole}-{u.IdCarrier}-{u.IdCompany}");
                }
            }
            Console.ReadKey();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>();

        }
    }
}
