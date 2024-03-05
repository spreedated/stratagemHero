using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record MachineGun : Stratagem
    {
        public MachineGun()
        {
            base.Name = "MG-43 Machine Gun";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("MG-43icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Right)
            ]);
        }
    }
}
