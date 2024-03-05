using System.Collections.Generic;
using System.ComponentModel;

namespace Helldivers2_Stratagem_Hero.Models
{
    public abstract record Stratagem
    {
        public string Name { get; init; }
        public byte[] Icon { get; init; }
        public Queue<StratagemKey> Keys { get; init; }
        public int Score
        {
            get
            {
                return this.Keys.Count * 5;
            }
        }
        public Categories Category { get; init; }

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

        public void Reset()
        {
            foreach (StratagemKey k in this.Keys)
            {
                k.Unset();
            }
        }

        public class StratagemKey
        {
            public enum Directions
            {
                Up,
                Down,
                Left,
                Right
            }

            public Directions Direction { get; init; }
            public bool IsHeld { get; private set; }

            #region Constructor
            public StratagemKey(Directions direction)
            {
                this.Direction = direction;
            }
            #endregion

            public void Set()
            {
                this.IsHeld = true;
            }

            public void Unset()
            {
                this.IsHeld = false;
            }
        }
    }
}
