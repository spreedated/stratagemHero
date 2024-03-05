using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record NapalmAirstrike : Stratagem
    {
        public NapalmAirstrike()
        {
            base.Name = "Eagle Napalm Airstrike";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("EagleNapalmicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up)
            ]);
        }
    }
}
