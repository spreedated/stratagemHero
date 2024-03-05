using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record HmgEmplacement : Stratagem
    {
        public HmgEmplacement()
        {
            base.Name = "E/MG-101 HMG Emplacement";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("HMGTurreticon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Left)
            ]);
        }
    }
}
