using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    internal class Vehicle 
    {
        public Vehicle(string registerNumber, string color, int numberOfWheels)
        {
            RegisterNumber = registerNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public string RegisterNumber { get; set;}
        public string Color { get; set;}
        public int NumberOfWheels { get; set;}
    }

    internal class Car : Vehicle
    {
        public int EngineVolume { get; set; }
        public Car(string registerNumber, string color, int numberOfWheels, int engineVolume)
            : base(registerNumber, color, numberOfWheels)
        {
            EngineVolume = engineVolume;
        }

       
    }

    internal class Motorcycle : Vehicle
    {
        public int MaxSpeed { get; set; }
        public Motorcycle(string registerNumber, string color, int numberOfWheels, int maxSpeed) 
            : base(registerNumber, color, numberOfWheels)
        {
            MaxSpeed = maxSpeed;
        }

        
    }

    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus(string registerNumber, string color, int numberOfWheels, int numberOfSeats) 
            : base(registerNumber, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

    }
}
