using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record Resupply : Stratagem
    {
        public Resupply()
        {
            base.Name = "Resupply";
            base.Category = Categories.Mission;
            base.Icon = LoadEmbeddedStratagem("ResupplyIcon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
