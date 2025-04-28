using ParallelProgrammingProject;

internal class RaceManager
{
    private readonly Race _race;
    private readonly List<Thread> _raceThreads = new();

    public RaceManager(Race race) => _race = race;

    public void StartRace(int raceLength)
    {
        foreach (var car in _race.Racers.Values)
        {
            var thread = new Thread(() =>
            {
                car.RunRace(raceLength, () =>
                {
                    RaceUpdated.Invoke(_race.Racers);
                });
            });

            _raceThreads.Add(thread);
            thread.Start();
        }
    }

    public void StopRace()
    {
        foreach (var car in _race.Racers.Values)
        {
            car.IsRacing = false;
        }
        _raceThreads.Clear();
    }

    public event Action<Dictionary<int, Car>> RaceUpdated;
}