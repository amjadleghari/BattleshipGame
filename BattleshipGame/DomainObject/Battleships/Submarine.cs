using System;

namespace BattleshipGame.DomainObjects.Battleships
{
    public class Submarine : Battleship
    {
        public Submarine()
        {
            GUID = Guid.NewGuid();
            Name = "Submarine";
            Width = 1;
            Length = 3;
        }
    }
}

