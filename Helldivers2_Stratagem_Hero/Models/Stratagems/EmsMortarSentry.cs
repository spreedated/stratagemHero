using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record EmsMortarSentry : Stratagem
    {
        public EmsMortarSentry()
        {
            base.Name = "A/M-23 EMS Mortar Sentry";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("EMSmortaricon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
