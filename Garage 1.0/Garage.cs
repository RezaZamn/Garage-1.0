using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage_1._0
{
    internal class Garage<T>
    {
        private Vehicle[] vehicles { get; set; }

        public Garage()
        {
            vehicles = new Vehicle[100];
        }


        internal IEnumerable<Vehicle> GetVehicles()
        {
            return vehicles.Where(vehicle => vehicle != null); //Returnerar de platser som inte är null. 
        }


        // Addar fordon till garaget
        internal void AddVehicle(Vehicle v)
        {
            if (v == null)
            { throw new ArgumentNullException(nameof(v), "Fordonet kan inte vara null"); }
            //Loopen går genom Arrayen och hittar den första lediga platsen
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null) //Kontrollerar om platsen är tom
                {
                    vehicles[i] = v;     // Lägger nya fordonet i den lediga platsen
                    return;
                }
            }

        }


        //Tar bort fordon från vehicles arrayen
        internal void RemoveVehicle(string registerNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                //Kollar om fordonens register nummer är lika med inmatade register nummer.
                if (vehicles[i].RegisterNumber == registerNumber)
                {
                    vehicles[i] = null; //Tar bort fordonet genom att sätta den platsen till null.
                    break;
                }

            }

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
            return null;
        }


    }
}
