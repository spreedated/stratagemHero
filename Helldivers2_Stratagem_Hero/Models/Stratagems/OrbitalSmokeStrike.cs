using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record OrbitalSmokeStrike : Stratagem
    {
        public OrbitalSmokeStrike()
        {
            base.Name = "Orbital Smoke Strike";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("OrbitalSmokeicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up)
            ]);
        }
    }
}
