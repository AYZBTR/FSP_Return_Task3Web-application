using FSP_Return_Task3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using System.Net;

namespace FSP_Return_Task3.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FSP_Return_Task3Context(serviceProvider.GetRequiredService<
                    DbContextOptions<FSP_Return_Task3Context>>()))
            {
                // Look for any students.
                if (context.Passenger.Any())
                {
                    return;   // DB has been seeded
                }

                var Passengers = new List<Passenger>
                {
                    new Passenger {FirstName = "Elon", LastName = "Musk", DateOfBirth =  new DateTime(1971,06,28)},

                    new Passenger {FirstName = "Bill", LastName = "Gates", DateOfBirth =  new DateTime(1955,10,28)},
                    new Passenger {FirstName = "Mark", LastName = "Zuckerberg", DateOfBirth = new DateTime(1984, 05, 14)},

                };



                //Because of FK keys:

                Passengers.ForEach(d => context.Passenger.Add(d));
                context.SaveChanges();

                var Passports = new List<Passport>
                {
                    new Passport{ PassengerId= 1, PassportNumber="11111A", ValidDate = new DateTime(2030,01,22) },
                    new Passport{ PassengerId= 2, PassportNumber="22222B", ValidDate = new DateTime(2035,05,25) },
                    new Passport{ PassengerId= 3, PassportNumber="333333C", ValidDate = new DateTime(2036,06,27) }
                };
                Passports.ForEach(p => context.Passport.Add(p));
                context.SaveChanges();
            }
        }
    }
}

 