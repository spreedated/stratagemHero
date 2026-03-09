using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Stratagems.Models
{
    public record Stratagem
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonIgnore]
        public byte[] Icon { get; init; }

        [JsonIgnore]
        public Queue<StratagemKey> Keys { get; init; }

        [JsonIgnore]
        public int Score
        {
            get
            {
                return this.Keys.Count * 5;
            }
        }

        [JsonPropertyName("category")]
        public Categories Category { get; init; }

        public void Reset()
        {
            foreach (StratagemKey k in this.Keys)
            {
                k.Unset();
            }
        }
    }
}
