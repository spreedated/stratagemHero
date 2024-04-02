using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record QuasarCannon : Stratagem
    {
        public QuasarCannon()
        {
            base.Name = "LAS-99 Quasar Cannon";
            base.Category = Categories.SWeapons;
            base.Icon = LoadEmbeddedStratagem("QuasarCannon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
