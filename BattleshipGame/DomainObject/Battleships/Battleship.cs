using System;
using System.Collections.Generic;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObjects.Battleships
{
    public abstract class Battleship
    {
        public Guid GUID { get; set; }

        public string Name { get; set; }
        
        public int Width { get; set; }

        public int Length { get; set; }

        public Alignment ShipAlignment { get; set;}

        public List<(Coordinates, string)> Placement { get; set; }

        public bool IsDestroyed()
        {
            bool retVal = Placement.TrueForAll(item => item.Item2.Equals(MoveOutcome.Hit.ToString()));
            return retVal;
        }

        public bool IsHit(Coordinates coordinates)
        {
            bool retVal = false;

            if (!IsDestroyed())
            {
                var index = Placement.FindIndex(item => item.Item1.XCoordinate == coordinates.XCoordinate && item.Item1.YCoordinate == coordinates.YCoordinate);

                if (index != -1)
                {
                    Placement[index] = (coordinates, MoveOutcome.Hit.ToString());
                    retVal = true;
                }
            }

            return retVal;
        }

        public bool BattleshipPlacement(Coordinates originationCoordinates)
        {
            bool retVal = true;

            int X = originationCoordinates.XCoordinate;
            int Y = originationCoordinates.YCoordinate;
            bool IsOutofBound = false;

            if (ShipAlignment == Alignment.Horizontal)
            {
                for (int lengthCounter = Y; lengthCounter < Length + Y; lengthCounter++)
                {
                    for (int widthCounter = 0; widthCounter < Width; widthCounter++)
                    {
                        if (lengthCounter > 10 || (X + widthCounter) > 10)
                        {
                            IsOutofBound = true;
                            break;
                        }
                        else
                            Placement.Add((new Coordinates(X + widthCounter, lengthCounter), MoveOutcome.UnHarmed.ToString()));
                    }
                }
            }
            else if (ShipAlignment == Alignment.Vertical)
            {
                for (int lengthCounter = X; lengthCounter < Length + X; lengthCounter++)
                {
                    for (int widthCounter = 0; widthCounter < Width; widthCounter++)
                    {
                        if (lengthCounter > 10 || (Y + widthCounter) > 10)
                        {
                            IsOutofBound = true;
                            break;
                        }
                        else
                            Placement.Add((new Coordinates(lengthCounter, Y + widthCounter), MoveOutcome.UnHarmed.ToString()));
                    }
                }
            }

            if (IsOutofBound)
                retVal = false;

            return retVal;
        }
    }
}