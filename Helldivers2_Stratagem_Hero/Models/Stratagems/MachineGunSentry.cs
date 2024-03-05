using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record MachineGunSentry : Stratagem
    {
        public MachineGunSentry()
        {
            base.Name = "A/MG-43 Machine Gun Sentry";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("MGsentryicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Up)
            ]);
        }
    }
}
