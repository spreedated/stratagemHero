using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record ShieldGeneratorRelay : Stratagem
    {
        public ShieldGeneratorRelay()
        {
            base.Name = "FX-12 Shield Generator Relay";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("Shieldrelayicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
