using MARS.Models;
using System;
using System.Collections.Generic;

namespace MARS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputList = {"5 5", "1 2 N", "LMLMLMLM", "M 3 3 E", "MMRMMRMRRM" };
            var mars = new Mars();
            var roverList = new List<Rover>();

            var marsValues = inputList[0].Split(" ");
            int i = 0;
            for ( ; i < marsValues.Length; i++)
                if (i == 0)
                    mars.XMax = Convert.ToInt16(marsValues[i]);
                else
                    mars.YMax = Convert.ToInt16(marsValues[i]);

            for (i = 1; i < inputList.Length; i++)
            {
                var commands = inputList[i].Split(" ");
                for (int k = 0; k < commands.Length; k++)
                {
                    var command = commands[k];
                    if (command.Length == 1 && Char.IsDigit(command[0])) // İnitialize Rover
                    {
                        var rover = new Rover();
                        rover.X = Convert.ToInt16(commands[k++]);
                        rover.Y = Convert.ToInt16(commands[k++]);
                        rover.Direction = (commands[k][0]);
                        rover.Mars = mars;
                        roverList.Add(rover);
                    }
                    else
                        if (roverList.Count != 0)
                        {
                            var lastRover = roverList[roverList.Count - 1];
                            lastRover.Process(command);
                        }
                }
            }

            roverList.ForEach(rover =>
            {
                Console.WriteLine($"{rover.X} {rover.Y} {rover.Direction}");
            });




                    // Bu kısım input'u dışarıdan alıyorsan diye kontrol edilerek yazıldı (Sadece Mars grid inputu için)
                    // Ancak inputları biz girdiğimizden dolayı böyle yazmaya gerek yok.

                    /* if (!string.IsNullOrEmpty(inputList[0]))
                    {
                        var marsValues = inputList[0].Split(" ");
                        if (marsValues.Length != 2)
                            ExitApp(-1, "Mars'ın grid uzunluklarını düzgün formatta bildirmelisiniz");

                        for (int i = 0; i < marsValues.Length; i++)
                            if (marsValues[i].Length == 1 && Char.IsDigit(marsValues[i][0])) { 
                                if (i == 0)
                                    mars.XMax = Convert.ToInt16(marsValues[i]);
                                else
                                    mars.YMax = Convert.ToInt16(marsValues[i]);
                            }
                            else
                                ExitApp(-1, "Mars'ın grid uzunluklarını düzgün formatta bildirmelisiniz");
                    }
                    else
                        ExitApp(-1, "Mars'ın grid uzunluklarını düzgün formatta bildirmelisiniz"); */
                }

        /* static void ExitApp(int exitCode, string message)
        {
            Console.WriteLine(message);
            Environment.Exit(exitCode);
        } */
    }
}
