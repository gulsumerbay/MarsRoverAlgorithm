using System;
using System.Collections.Generic;

namespace MarsRoverAlgorithm
{
    public class Position
    {
        public Position((int X, int Y) maxPoint)
        {
            maxPoints = maxPoint;
        }
        public static (int X, int Y) maxPoints;
        private int x;
        private int y;
        public int X { 
            get { return x; } 
            set 
            { 
                if(value < 0 || value > maxPoints.X) 
                    throw new Exception($"Rover is out of X Positions (0,{maxPoints.X}) ");

                x = value; 
            }   
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0 || value > maxPoints.Y)
                    throw new Exception($"Rover is out of Y Positions (0,{maxPoints.Y}) ");
                y = value;
            }
        }
        public Directions Direction { get; set; }
        public string Orientation { get; set; }
        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }
        private void GoStraight()
        {
            this.Y += this.Direction switch
            {
                Directions.N => 1,
                Directions.S => -1,
                _ => 0,
            };
            this.X += this.Direction switch
            {
                Directions.E => 1,
                Directions.W => -1,
                _ => 0,
            };
        }
        public void Move()
        {
            foreach (var letter in Orientation)
            {
                switch (letter)
                {
                    case 'M': this.GoStraight(); break;
                    case 'L': this.TurnLeft(); break;
                    case 'R': this.TurnRight(); break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
       
    }
}
