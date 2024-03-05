using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record RecoillessRifle : Stratagem
    {
        public RecoillessRifle()
        {
            base.Name = "GR-8 Recoilless Rifle";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("GR-8icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
