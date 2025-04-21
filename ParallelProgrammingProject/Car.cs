using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgrammingProject
{
    internal class Car
    {
        internal string Make;
        internal string Model;
        internal int Year;
        internal int HorsePower;
        internal int Weight;

        internal Car()
        {
            Make = "Toyota";
            Model = "Yaris";
            Year = 2009;
            HorsePower = 100;
            Weight = 1000;
        }

        internal Car(string make, string model, int year, int hp, int w)
        {
            Make = make;
            Model = model;
            Year = year;
            HorsePower = hp;
            Weight = w;
        }
    }
}
