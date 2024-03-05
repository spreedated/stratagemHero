using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record OrbitalAirburstStrike : Stratagem
    {
        public OrbitalAirburstStrike()
        {
            base.Name = "Orbital Airburst Strike";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("OrbitalAirbursticon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
