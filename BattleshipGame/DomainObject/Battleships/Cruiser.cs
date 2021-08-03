using System;

namespace BattleshipGame.DomainObjects.Battleships
{
    public class Cruiser : Battleship
    {
        public Cruiser()
        {
            GUID = Guid.NewGuid();
            Name = "Cruiser";
            Width = 1;
            Length = 4;
        }
    }

}