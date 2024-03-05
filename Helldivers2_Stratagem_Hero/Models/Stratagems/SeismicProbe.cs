using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record SeismicProbe : Stratagem
    {
        public SeismicProbe()
        {
            base.Name = "Seismic Probe";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("Seismic_probe_icon");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Left),
                new StratagemKey(StratagemKey.Directions.Right),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down)
            ]);
        }
    }
}
