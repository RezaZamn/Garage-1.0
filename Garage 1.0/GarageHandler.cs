using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage_1._0
{
    internal class GarageHandler
    {
        Garage<Vehicle> garage = new Garage<Vehicle>();
        string registerNumber;
        string color;
        int engineVolume;
        int antalHjul;
        int maxSpeed;
        int numberOfSeats;

        //Tar emot sträng värden och kan användas för inmatningen
        public static string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt}:");
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"You must enter a valid {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        //Tar emot Int värden och kan användas för inmatningen
        public static int AskForInt(string prompt)
        {
            int result = 0;
            do
            {
                string input = AskForString(prompt);
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid {prompt}");
                }


            } while (true);
        }



        public void AddVehicleHelperCar()
        {
            registerNumber = AskForString("RegisterNumber");
            color = AskForString("Color");
            engineVolume = AskForInt("engineVolume");
            antalHjul = AskForInt("AntalHjul");

            Car newCar = new Car(registerNumber, color, antalHjul, engineVolume);
            garage.AddVehicle(newCar);

        }

        public void RemoveVehicleHelper()
        {
            Console.WriteLine("Ange Registernummer på bilen som ska tas bort:");
            registerNumber = Console.ReadLine();
            garage.RemoveVehicle(registerNumber);
           
        }

        public void AddVehicleHelperMotorcycle()
        {

            //Console.WriteLine("Ange Registernummer:");
            //registerNumber = Console.ReadLine();

            //Console.WriteLine("Ange Color:");
            //color = Console.ReadLine();

            //Console.WriteLine("Ange max speed:");
            //maxSpeed = int.Parse(Console.ReadLine());

            //Console.WriteLine("Ange antal hjul:");
            //antalHjul = int.Parse(Console.ReadLine());

            registerNumber = AskForString("RegisterNumber");
            color = AskForString("Color");
            maxSpeed = AskForInt("engineVolume");
            antalHjul = AskForInt("AntalHjul");

            Motorcycle newMotorcycle = new Motorcycle(registerNumber, color, antalHjul, maxSpeed);

            garage.AddVehicle(newMotorcycle);

        }

        public void AddVehicleHelperBus()
        {
            registerNumber = AskForString("RegisterNumber");
            color = AskForString("Color");
            numberOfSeats = AskForInt("engineVolume");
            antalHjul = AskForInt("AntalHjul");

            Bus newBus = new Bus(registerNumber, color, antalHjul, numberOfSeats);

            garage.AddVehicle(newBus);
        }

        public void GetVehicleHelper()
        {
            IEnumerable<Vehicle> totalVehicles = garage.GetVehicles();
            Console.WriteLine($"Antal fordon: {totalVehicles.Count()}");

            foreach (Vehicle vehicle in totalVehicles)
            {
                if (vehicle is Car car)
                {
                    Console.WriteLine($"Bilen med regnummer {car.RegisterNumber}, {car.Color} färg och {car.NumberOfWheels} antal hjul och {car.EngineVolume} motorvolym är parkerad.");
                }


                else if (vehicle is Motorcycle motorcycle)
                {

                    Console.WriteLine($"Motorcycle med regnummer {motorcycle.RegisterNumber}, {motorcycle.Color} färg och {motorcycle.NumberOfWheels} antal hjul och Max speed {motorcycle.MaxSpeed} är parkerad.");

                }

                else if (vehicle is Bus bus)
                {

                    Console.WriteLine($"Bussen med regnummer {bus.RegisterNumber}, {bus.Color} färg och {bus.NumberOfWheels} antal hjul och {bus.NumberOfSeats} antal säten är parkerad.");
                }
            }
           
            Console.WriteLine();
        }


        public void SeekVehicleHelper()
        {
            Console.WriteLine("Ange din sök ord:");
            string seekWord = Console.ReadLine();
            IEnumerable<Vehicle> result = garage.FindVehicle(seekWord);

            if (result != null)
                foreach (Vehicle vehicle1 in result)
                {
                    if (vehicle1 != null)
                    {
                        Console.WriteLine($"Hittade fordon är: {vehicle1.GetType().Name} Färg:{vehicle1.Color} RegNr:{vehicle1.RegisterNumber}");
                    }
                }

            else
            {
                Console.WriteLine("Hittades inga fordon för denna sökning");
            }
        }



    }
}
