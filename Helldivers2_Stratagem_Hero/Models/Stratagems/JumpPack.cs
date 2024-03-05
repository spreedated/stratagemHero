using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record JumpPack : Stratagem
    {
        public JumpPack()
        {
            base.Name = "LIFT-850 Jump Pack";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("LIFT-850icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up)
            ]);
        }
    }
}
