using System;

namespace BattleshipGame.DomainObjects.Battleships
{
    public class Destroyer: Battleship
    {
        public Destroyer()
        {
            GUID = Guid.NewGuid();
            Name = "Destroyer";
            Width = 1;
            Length = 3;
        }
    }

}