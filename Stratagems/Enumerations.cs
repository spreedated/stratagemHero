using System.ComponentModel;

namespace Stratagems
{
    public enum Categories
    {
        [Description("Supply: Backpacks")]
        SBackpack,
        [Description("Supply: Secondary Weapons")]
        SWeapons,
        [Description("Mission Stratagems")]
        Mission,
        [Description("Defensive")]
        Defensive,
        [Description("Offensive: Orbital")]
        OffensiveOrbital,
        [Description("Offensive: Eagle")]
        OffensiveEagle
    }
}
