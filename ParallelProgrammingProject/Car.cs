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
        private readonly object locker = new();
        private int _progress;
        private int _raceTime;
        private bool _isRacing;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public int Weight { get; set; }
        public int Progress 
        {
            get { lock (locker) return _progress; }
            set { lock (locker) _progress = value; }
        }
        public int RaceTime 
        {
            get { lock (locker) return _raceTime; }
            set { lock (locker) _raceTime = value; }
        }
        public bool IsRacing
        {
            get { lock (locker) return _isRacing; }
            set { lock (locker) _isRacing = value; }
        }
        public double Speed => (double)HorsePower / Weight;

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

        public void RunRace(int raceLength, Action progressUpdate)
        {
            lock (locker)
            {
                _isRacing = true;
            }
            var random = new Random();
            while (Progress < raceLength && IsRacing)
            {
                int delay = (int)(100 / Speed) + random.Next(1, 20);
                Thread.Sleep(delay);

                lock (locker)
                {
                    _progress++;
                    _raceTime += delay;
                }

                progressUpdate.Invoke();
            }

            lock (locker)
            {
                _isRacing = false;
            }
        }
    }
}
