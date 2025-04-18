using System;
using System.Collections.Generic;
using System.Linq;
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
