using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record BallisticShieldBackpack : Stratagem
    {
        public BallisticShieldBackpack()
        {
            base.Name = "SH-20 Ballistic Shield Backpack";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("SH-20icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
