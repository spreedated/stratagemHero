using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record GuardDogRover : Stratagem
    {
        public GuardDogRover()
        {
            base.Name = "AX/LAS-5 \"Guard Dog\" Rover";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("AX-LAS-5icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
