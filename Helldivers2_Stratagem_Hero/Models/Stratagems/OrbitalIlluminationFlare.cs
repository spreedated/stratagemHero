using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record OrbitalIlluminationFlare : Stratagem
    {
        public OrbitalIlluminationFlare()
        {
            base.Name = "Orbital Illumination Flare";
            base.Category = Categories.Mission;
            base.Icon = LoadEmbeddedStratagem("IlluminationFlare");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
