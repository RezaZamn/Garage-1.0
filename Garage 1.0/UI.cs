using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage_1._0
{
    internal class UI
    {
        Garage<Vehicle> garage = new Garage<Vehicle>();
        GarageHandler gh = new GarageHandler();


        bool isAlive = true;

        internal void StartProgram()
        {
            string registerNumber;
            do
            {
                Console.WriteLine("Det här är huvudmenyn,ni kan komma åt funktioner nedan med tillhörande nummer." +
                    "\n - - - - - - - - - - - - - - - - - - - - - - - -" +
                       "\n1: Lägga till fordon                           -" +
                       "\n2: Ta bort fordon                              -" +
                       "\n3: Skriva ut alla fordon                       -" +
                       "\n4: Sök efter fordon                            -" +
                       "\n0: Slutar programmet                           -" +
                    "\n - - - - - - - - - - - - - - - - - - - - - - - -");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Välj typ av fordon som ska parkera, (1) för bil, (2) för motorcykle , (3) for buss");

                        int valFordon = int.Parse(Console.ReadLine());

                        if (valFordon == 1)
                        {                          
                           gh.AddVehicleHelperCar();
                        }
                        else if (valFordon == 2)
                        {                            
                            gh.AddVehicleHelperMotorcycle();
                        }

                        else if (valFordon == 3)
                        {
                          gh.AddVehicleHelperBus();

                        }
                        break;


                    case "2":
                        Console.WriteLine("Ange Registernummer på bilen som ska tas bort:");
                        registerNumber = Console.ReadLine();
                        garage.RemoveVehicle(registerNumber);
                        break;


                    case "3":
                        IEnumerable<Vehicle> vehicles = garage.GetVehicles();

                        if (vehicles == null || !vehicles.Any())
                        {
                            Console.WriteLine("inga bil parkerade i garaget");
                        }
                        else
                        {

                            foreach (Vehicle veh in vehicles)
                            {
                                if (veh is Car car)
                                {
                                    Console.WriteLine($"Bilen med regnummer {car.RegisterNumber}, {car.Color} färg och {car.NumberOfWheels} antal hjul och {car.EngineVolume} motorvolym är parkerad.");
                                }


                                else if (veh is Motorcycle motorcycle)
                                {

                                    Console.WriteLine($"Motorcycle med regnummer {motorcycle.RegisterNumber}, {motorcycle.Color} färg och {motorcycle.NumberOfWheels} antal hjul och Max speed {motorcycle.MaxSpeed} är parkerad.");

                                }

                                else if (veh is Bus bus)
                                {

                                    Console.WriteLine($"Bussen med regnummer {bus.RegisterNumber}, {bus.Color} färg och {bus.NumberOfWheels} antal hjul och {bus.NumberOfSeats} antal säten är parkerad.");
                                }
                            }
                        }

                        Console.WriteLine();
                        break;



                    case "4":
                        Console.WriteLine("Ange din sök ord:");
                        string seekWord = Console.ReadLine();
                        IEnumerable<Vehicle> result = garage.FindVehicle(seekWord);
                  

                        if (result.Any())
                            foreach (Vehicle vehicle1 in result)
                            {
                                if(vehicle1!= null)
                                {
                                    Console.WriteLine($"Hittade fordon är: {vehicle1.GetType().Name} Färg:{vehicle1.Color} RegNr:{vehicle1.RegisterNumber}");
                                }
                            }

                        else
                        {
                           Console.WriteLine("Hittades inga fordon för denna sökning");
                        }
                        
                        break;


                    case "0":
                        isAlive = false;
                        break;

                }
            } while (isAlive);
        }

    }
}
