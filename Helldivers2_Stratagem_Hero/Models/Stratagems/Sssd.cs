using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record Sssd : Stratagem
    {
        public Sssd()
        {
            base.Name = "SSSD Delivery";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("DeliverSSSDicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Up)
            ]);
        }
    }
}
