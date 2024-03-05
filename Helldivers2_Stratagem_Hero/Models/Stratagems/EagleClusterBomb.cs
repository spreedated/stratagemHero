using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record EagleClusterBomb : Stratagem
    {
        public EagleClusterBomb()
        {
            base.Name = "Eagle Cluster Bomb";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("EagleClusterbombicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
