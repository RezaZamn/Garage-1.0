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
        int? numberOfWheels;

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

        
       

    }
}
