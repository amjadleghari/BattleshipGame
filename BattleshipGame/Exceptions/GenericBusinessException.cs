using System;
namespace BattleshipGame.Exceptions
{
    public class GenericBusinessException : Exception
    {
        public GenericBusinessException()
        {
        }

        public GenericBusinessException(string message) : base(message)
        {
        }
    }
}
