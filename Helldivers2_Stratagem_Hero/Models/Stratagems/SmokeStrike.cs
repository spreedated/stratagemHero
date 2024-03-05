using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record SmokeStrike : Stratagem
    {
        public SmokeStrike()
        {
            base.Name = "Eagle Smoke Strike";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("EagleSmokeicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
