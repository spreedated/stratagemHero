#pragma warning disable S101

using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record _500kgBomb : Stratagem
    {
        public _500kgBomb()
        {
            base.Name = "Eagle 500kg Bomb";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("Eagle500icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
