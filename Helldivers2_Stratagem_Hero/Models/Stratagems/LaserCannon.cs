using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record LaserCannon : Stratagem
    {
        public LaserCannon()
        {
            base.Name = "LAS-98 Laser Cannon";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("LAS-98icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
