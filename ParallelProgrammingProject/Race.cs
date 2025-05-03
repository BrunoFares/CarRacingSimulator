using System;
using System.Collections.Generic;

namespace ParallelProgrammingProject
{
    public class Race
    {
        internal Dictionary<int, Car> Racers { get; set; } = new();
        public List<Car> Leaderboard { get; private set; } = new();
        private readonly object leaderboardLock = new();

        // Default cars with default attributes
        internal Race()
        {
            Racers[0] = new Car("Toyota", "Yaris", 2009, 100, 1000);
            Racers[1] = new Car("Ferrari", "296 GTB", 2025, 819, 1500);
        }

        public void AddCar(Car car)
        {
            Racers[Racers.Count] = car;
        }

        public void ResetRace()
        {
            foreach (var car in Racers.Values)
            {
                car.Progress = 0;
                car.InPitStop = false;
                car.HorsePower = car.OriginalHorsePower;
                car.Weight = car.OriginalWeight;
            }

            Leaderboard.Clear();
        }

        public void AddToLeaderboard(Car car)
        {
            lock (leaderboardLock)
            {
                if (!Leaderboard.Contains(car))
                    Leaderboard.Add(car);
            }
        }
    }
}