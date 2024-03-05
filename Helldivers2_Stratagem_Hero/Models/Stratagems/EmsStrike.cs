using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record EmsStrike : Stratagem
    {
        public EmsStrike()
        {
            base.Name = "Orbital EMS Strike";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("OrbitalEMSicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
