using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record Sos : Stratagem
    {
        public Sos()
        {
            base.Name = "SOS Beacon";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("SOSicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Up)
            ]);
        }
    }
}
