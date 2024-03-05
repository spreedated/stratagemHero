using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record IncendiaryMines : Stratagem
    {
        public IncendiaryMines()
        {
            base.Name = "MD-I4 Incendiary Mines";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("Fireminefieldicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
