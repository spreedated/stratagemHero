#pragma warning disable S101

using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record Orbital120mmBarrage : Stratagem
    {
        public Orbital120mmBarrage()
        {
            base.Name = "Orbital 120MM HE Barrage";
            base.Category = Categories.OffensiveOrbital;
            base.Icon = LoadEmbeddedStratagem("Orbital120icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
