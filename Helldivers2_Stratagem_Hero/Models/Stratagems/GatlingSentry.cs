using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record GatlingSentry : Stratagem
    {
        public GatlingSentry()
        {
            base.Name = "A/G-16 Gatling Sentry";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("Gatlingsentryicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
