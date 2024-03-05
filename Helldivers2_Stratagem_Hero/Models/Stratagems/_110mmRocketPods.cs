#pragma warning disable S101

using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record _110mmRocketPods : Stratagem
    {
        public _110mmRocketPods()
        {
            base.Name = "Eagle 110MM Rocket Pods";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("EagleRocketpodicon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
