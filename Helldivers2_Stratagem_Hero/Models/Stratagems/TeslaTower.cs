using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record TeslaTower : Stratagem
    {
        public TeslaTower()
        {
            base.Name = "A/ARC-3 Tesla Tower";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("Teslaicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
