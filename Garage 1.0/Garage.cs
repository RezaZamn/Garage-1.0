using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage_1._0
{
    internal class Garage<T> where T : Vehicle
    {
        private Vehicle[] vehicles { get; set; }

        public Garage()
        {
            vehicles = new Vehicle[100];
        }


        // Addar fordon till garaget
        internal void AddVehicle(Vehicle vehicle)
        {
            //Kollar om fordonet är null
            if (vehicle == null)
            { throw new ArgumentNullException(nameof(vehicle), "Fordonet kan inte vara null."); }

            //Loopen går genom Arrayen och hittar den första lediga platsen
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null) //Kontrollerar om platsen är tom
                {
                    vehicles[i] = vehicle;     // Lägger nya fordonet i den lediga platsen
                    Console.WriteLine($"Fordonet med registernummret {vehicle.RegisterNumber} har lagts till.");
                    return;
                }
            }

            Console.WriteLine("Garaget är full och finns inga lediga platser.");

        }

        internal IEnumerable<Vehicle> GetVehicles()
        {
            return vehicles.Where(vehicle => vehicle != null); //Returnerar de platser som inte är null. 
        }


        //Tar bort fordon från vehicles arrayen
        internal bool RemoveVehicle(string registerNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                //Kollar om fordonens register nummer är lika med inmatade register nummer.
                if (vehicles[i] != null && vehicles[i].RegisterNumber == registerNumber)
                {
                    vehicles[i] = null; //Tar bort fordonet genom att sätta den platsen till null.
                    Console.WriteLine($"Fordonet med registernummret {registerNumber} har tagits bort.");
                    return true;
                }

            }
            Console.WriteLine("Fordonet hittades inte");        
            return false;
        }


        //En metod som kan söka genom garaget
        internal IEnumerable<Vehicle> FindVehicle(string userSearchWords)
        {

            //Delar upp användarens input i en array av ord
            string[] searchWords = userSearchWords?.Split(' ');

            string colorInput = ColorChoosed(userSearchWords);

            //Söker genom garaget med LINQ frågor
            IQueryable<Vehicle> query = vehicles.AsQueryable();

            query = query.Where(vehicle => (searchWords.Contains("bil") && vehicle is Car) ||
                                           (searchWords.Contains("motorcykel") && vehicle is Motorcycle) ||
                                           (searchWords.Contains("buss") && vehicle is Bus) ||
                                           searchWords.Any(searchWords => searchWords == vehicle.RegisterNumber.ToLower()) ||                                          
                                           (vehicle.Color.ToLower() == colorInput));

            return query;
        }

        //En metod som kollar att inmatade värde är lika med en av färger i arrayen
        internal string ColorChoosed(string input)
        {
            string[] colors = { "vit", "röd", "blå", "brun", "gul", "grön", "grå", "svart" };

            foreach (string color in colors)
            {
                if (input.Equals(color))
                {
                    return color;
                }

            }
            return string.Empty;
        }


    }
}
