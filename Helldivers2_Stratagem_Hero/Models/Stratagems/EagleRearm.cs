using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record EagleRearm : Stratagem
    {
        public EagleRearm()
        {
            base.Name = "Eagle Rearm";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("HD2_Eagle_Rearm_Icon.png");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
