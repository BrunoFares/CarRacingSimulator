# Car Racing Simulator

This is a project by Bruno Fares, Andrea Moubarak and Jason Moussi, which we completed for our university's Parallel Programming class.

## 1. Overview

The idea was to build a car drag racing simulator, meaning a straight-line race between a given number of cars. 
Each car is represented by a progress bar, which implements a Progress object that has its value incremented every few milliseconds.
Each car's progress bar runs on a separate thread, with different cars competing simultaneously of course.

## 2. Activities

### Activity 1: Adding cars

The user will first need to line up the cars on the track, initially empty. For every car the user adds, they will need to enter its specifications: make, model, 
year, stock/modified, horsepower, weight. As you might have guessed, the horsepower and weight entered will have an impact on the speed of the car.
Threads and asynchronous functions were used. 

### Activity 2: Pit Stop Manoeuver

The user is also able to perform a “pit stop maneuver”: they choose whichever running car they desire, and can modify some of its specifications, 
such as adding/removing weight or horsepower to it, using signals mostly.

### Activity 3: Leaderboard

When the race finally ends, the user is able to see a leaderboard showing the cars’ positions in the race and each one’s respective time, using task combinators.

## 3. Implementation

This project was developed using C# on the .NET Framework, utilizing Windows Forms for the user interface, and built within Microsoft Visual Studio.
