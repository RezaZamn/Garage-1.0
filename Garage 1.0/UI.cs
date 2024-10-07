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

               
                 int input = int.Parse(Console.ReadLine());
                    if (input < 0 || input > 4)
                    {
                        Console.WriteLine("Matade värde ska vara mellan 0 - 4");
                    }


                    switch (input)
                {
                    case 1:
                        Console.WriteLine("Välj typ av fordon som ska parkera, (1) för bil, (2) för motorcykle , (3) for buss");

                        int valFordon = int.Parse(Console.ReadLine());
                        if (valFordon < 1 || valFordon > 3)
                        {
                            Console.WriteLine("Matade värde ska vara mellan 1 - 3");
                        }

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
                        Console.WriteLine();
                        break;


                    case 2:                       
                        gh.RemoveVehicleHelper();
                        break;


                    case 3:                       
                        gh.GetVehicleHelper();
                        break;



                    case 4:
                        gh.SeekVehicleHelper();
                        break;


                    case 0:
                        isAlive = false;
                        break;


                    default:
                        Console.WriteLine("Ogiltig input, försök igen.");
                        break;


                }
            } while (isAlive);
        }

    }
}
