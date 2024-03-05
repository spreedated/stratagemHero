using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record StrafingRun : Stratagem
    {
        public StrafingRun()
        {
            base.Name = "Eagle Strafing Run";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("EagleStrafingicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
