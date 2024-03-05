using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record GrenadeLauncher : Stratagem
    {
        public GrenadeLauncher()
        {
            base.Name = "GL-21 Grenade Launcher";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("GL-21icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
