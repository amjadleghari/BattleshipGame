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

        public List<Coordinates> Placement { get; set; }

        public bool IsDestroyed()
        {
            return false;
        }

        public List<Coordinates> GenerateBattleshipCoordinates(Coordinates originationCoordinates)
        {
            List<Coordinates> battleshipCoordinate = new List<Coordinates>();
            battleshipCoordinate.Add(originationCoordinates);
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
                        battleshipCoordinate.Add(new Coordinates(X, counter));
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
                        battleshipCoordinate.Add(new Coordinates(counter, Y));
                }
            }

            if (IsOutofBound)
                battleshipCoordinate = null;

            return battleshipCoordinate;
        }
    }
}