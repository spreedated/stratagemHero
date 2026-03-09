using Stratagems.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Stratagems
{
    public class Core
    {
        private readonly List<Stratagem> stratagems = [];

        public IReadOnlyList<Stratagem> Stratagems { get => this.stratagems; }
        public bool IsLoaded { get; private set; }

        public async Task Load()
        {
            if (this.IsLoaded)
            {
                return;
            }

            using (Stream s = typeof(Core).Assembly.GetManifestResourceStream("Stratagems.Data.stratagems.json"))
            {
                JsonDocument j = await JsonDocument.ParseAsync(s);
                foreach (JsonElement je in j.RootElement.GetProperty("stratagems").EnumerateArray())
                {
                    Stratagem st = je.Deserialize<Stratagem>();

                    using (Stream si = typeof(Core).Assembly.GetManifestResourceStream($"Stratagems.Images.{je.GetProperty("icon").GetString()}.png"))
                    {
                        await si.ReadExactlyAsync(st.Icon, 0, (int)si.Length);
                    }

                    st.Keys = [];

                    this.stratagems.Add(st);
                }
            }

            this.IsLoaded = true;
        }
    }
}
