using System.ComponentModel;
using System.Runtime.Serialization;

namespace BattleshipGame.Entities
{
    public enum Alignment
    {
        [Description("Vertical")]
        Vertical,
        [Description("Horizontal")]
        Horizontal
    }

    public enum MoveOutcome
    {
        [Description("Hit")]
        Hit,
        [Description("Miss")]
        Miss,
        [Description("UnHarmed")]
        UnHarmed
    }

    public enum ErrorMessages
    {
        [Description("Player name empty")]
        EmptyPlayerName,

        [Description("GUID empty or invalid")]
        GUIDInvalid,

        [Description("X Coordinate value should be between 1 and 10 inclusive")]
        XCoordinateInvalid,

        [Description("Y Coordinate value should be between 1 and 10 inclusive")]
        YCoordinateInvalid
    }
}