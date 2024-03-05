using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record AntiMaterielRifle : Stratagem
    {
        public AntiMaterielRifle()
        {
            base.Name = "APW-1 Anti-Materiel Rifle";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("APW-1icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
