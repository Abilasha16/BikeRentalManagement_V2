using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagement_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localDb)\\MSSQLLocalDB;Database=BikeRentalManagement";

            BikeRepository repository = new BikeRepository(connectionString);


            int option = 0;

            do
            {
                Console.WriteLine("\nBike Rental Management System:");
                Console.WriteLine("1. Add a Bike");
                Console.WriteLine("2. View All Bikes");
                Console.WriteLine("3. Update a Bike");
                Console.WriteLine("4. Delete a Bike");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option:");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter Bike Id:");
                        string id = Console.ReadLine();
                        Console.Write("Enter Bike Brand: ");
                        string brand = Console.ReadLine();
                        Console.Write("Enter Bike model:");
                        string model = Console.ReadLine();
                        Console.Write("Enter Bike rental price:");
                        decimal price = decimal.Parse(Console.ReadLine());
                        repository.AddBike(new Bike(id, brand, model, price));

                        break;
                    case 2:
                        repository.GetBikes();
                        break;
                    case 3:
                        Console.Write("Enter the Bike ID to update:");
                        string updateid = Console.ReadLine();
                        Console.Write("Enter new Brand:");
                        string newbrand = Console.ReadLine();
                        Console.Write("Enter new Model:");
                        string newmodel = Console.ReadLine();
                        Console.Write("Enter new rental Price:");
                        decimal newPrice = decimal.Parse(Console.ReadLine());

                        repository.EditBike(updateid, newbrand, newmodel, newPrice);
                        break;
                    case 4:
                        Console.Write("Enter the Bike ID to delete:");
                        string deleteId = Console.ReadLine();
                        repository.DeleteBike(deleteId);
                        break;
                    case 5:
                        Console.WriteLine("Exit..");
                        break;
                    default:
                        Console.WriteLine("Please input a number in 1-5");
                        break;

                }

            } while (option != 5);
        }
    }
}
