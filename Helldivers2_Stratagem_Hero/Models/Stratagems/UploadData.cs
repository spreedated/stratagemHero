using System.Collections.Generic;
using static Helldivers2_Stratagem_Hero.Logic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Models.Stratagems
{
    public sealed record UploadData : Stratagem
    {
        public UploadData()
        {
            base.Name = "Upload Data";
            base.Category = Categories.SBackpack;
            base.Icon = LoadEmbeddedStratagem("HD2_Upload_Data_Icon.png");
            base.Keys = new Queue<StratagemKey>(
            [
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Down),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Up),
                new StratagemKey(StratagemKey.Directions.Up)
            ]);
        }
    }
}
