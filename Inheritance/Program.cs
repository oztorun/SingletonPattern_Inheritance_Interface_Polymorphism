using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance
{
    class Vehicle
    {
        string name;
        int enginepower;
        int torque;
        int wheel;

        public Vehicle(string _name,int _torque, int _enginepower, int _wheel)
        {
            name = _name;
            enginepower = _enginepower;
            torque = _torque;
            wheel = -wheel;
        }

        public int truePower()
        {
            return (enginepower * torque) / 100;
        }


    }

   

    class Motorcycle : Vehicle
    {

        public Motorcycle(string _name, int _torque,int  _enginepower,int _wheel)
            : base(_name,_torque,_enginepower,_wheel)
        { }

        public int balance()
        {
            return truePower() / 2;
        }
    
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle1 = new Vehicle("Mercedes", 350, 220, 4);
            Vehicle vehicle2 = new Vehicle("BMW", 300, 250, 4);

            Console.WriteLine("*****Vehicle Spefications******");

            Console.WriteLine("First Car True Power : " + vehicle1.truePower());
            Console.WriteLine("Second Car True Power : " + vehicle2.truePower());

            Motorcycle motorcycle1 = new Motorcycle("Yamaha", 420, 120, 2);
            Motorcycle motorcycle2 = new Motorcycle("Honda", 370, 130, 2);

            Console.WriteLine("******Motorcycle Spefications*****");

            Console.WriteLine("First MotorCycle True Power:" + motorcycle1.truePower());
            Console.WriteLine("Second MotorCycle True Power:" + motorcycle2.truePower());

            Console.WriteLine("*****0About Balance For MotorCycle******");
            Console.WriteLine("First MotorCycle Balance =" + motorcycle1.balance());
            Console.WriteLine("Second MotorCycle Balance =" + motorcycle2.balance());


            Console.ReadKey();
        }
    }
}
