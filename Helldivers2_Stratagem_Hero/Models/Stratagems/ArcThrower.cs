using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record ArcThrower : Stratagem
    {
        public ArcThrower()
        {
            base.Name = "ARC-3 Arc Thrower";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("ARC-3icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
