using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record AntiPersonnelMinefield : Stratagem
    {
        public AntiPersonnelMinefield()
        {
            base.Name = "MD-6 Anti-Personnel Minefield";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("Minefieldicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
