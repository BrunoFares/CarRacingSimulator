using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgrammingProject
{
    internal class Race
    {
        internal List<Car> racers = new();

        internal Race()
        {
            racers.Add(new Car("Toyota", "Yaris", 2009, 100, 1000));
            racers.Add(new Car("Ferrari", "296 GTB", 2025, 819, 1500));
        }
    }
}
