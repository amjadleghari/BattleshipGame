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

        public List<(Coordinates, MoveOutcome)> Placement { get; set; }

        public bool IsDestroyed()
        {
            bool retVal = Placement.TrueForAll(item => item.Item2 == MoveOutcome.Hit);
            return retVal;
        }

        public bool IsHit(Coordinates coordinates)
        {
            bool retVal = false;

            if (!IsDestroyed())
            {
                var index = Placement.FindIndex(item => item.Item1 == coordinates);

                if (index != -1)
                {
                    Placement[index] = (coordinates, MoveOutcome.Hit);
                }
            }

            return retVal;
        }

        public bool BattleshipPlacement(Coordinates originationCoordinates)
        {
            bool retVal = true;

            Placement.Add((originationCoordinates,MoveOutcome.UnHarmed));
            int X = originationCoordinates.XCoordinate;
            int Y = originationCoordinates.YCoordinate;
            bool IsOutofBound = false;

            if (ShipAlignment == Alignment.H)
            {
                for (int counter = Y; counter < Length; counter++)
                {
                    if (counter > 10)
                    {
                        IsOutofBound = true;
                        break;
                    }
                    else
                        Placement.Add((new Coordinates(X, counter), MoveOutcome.UnHarmed));
                }
            }
            else if (ShipAlignment == Alignment.V)
            {
                for (int counter = X; counter < Length; counter++)
                {
                    if (counter > 10)
                    {
                        IsOutofBound = true;
                        break;
                    }
                    else
                        Placement.Add((new Coordinates(counter, Y), MoveOutcome.UnHarmed));
                }
            }

            if (IsOutofBound)
                retVal = false;

            return retVal;
        }
    }
}