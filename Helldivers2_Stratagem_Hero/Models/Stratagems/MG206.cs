using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record MG206 : Stratagem
    {
        public MG206()
        {
            base.Name = "MG-206 Heavy Machine Gun";
            base.Category = Categories.SWeapons;
            base.Icon = LoadEmbeddedStratagem("MG-206");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
