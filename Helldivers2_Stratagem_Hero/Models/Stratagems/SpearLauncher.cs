using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record SpearLauncher : Stratagem
    {
        public SpearLauncher()
        {
            base.Name = "FAF-14 SPEAR Launcher";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("FAF-14icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
