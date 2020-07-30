using System;
using System.Collections.Generic;
using System.Text;

namespace MARS.Models
{
    public class Rover
    {
        public short X { get; set; }
        public short Y { get; set; }
        public char Direction { get; set; }
        public Mars Mars { get; set; }

        public void Process(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
                if (commands[i] == 'L')
                    TurnLeft();
                else if (commands[i] == 'R')
                    TurnRight();
                else if (commands[i] == 'M')
                    MoveForward();
        }

        private void TurnLeft()
        {
            if (Direction == 'N')
                Direction = 'W';
            else if (Direction == 'W')
                Direction = 'S';
            else if (Direction == 'S')
                Direction = 'E';
            else if (Direction == 'E')
                Direction = 'N';
        }

        private void TurnRight()
        {
            if (Direction == 'N')
                Direction = 'E';
            else if (Direction == 'W')
                Direction = 'N';
            else if (Direction == 'S')
                Direction = 'W';
            else if (Direction == 'E')
                Direction = 'S';
        }

        private void MoveForward()
        {
            if (Direction == 'N' && Y != Mars.YMax)
                Y++;
            else if (Direction == 'W' && X != 0)
                X--;
            else if (Direction == 'S' && Y != 0)
                Y--;
            else if (Direction == 'E' && X != Mars.XMax)
                X++;
        }
    }
}
