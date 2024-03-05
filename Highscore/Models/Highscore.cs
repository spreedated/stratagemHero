using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Highscore.Models
{
    public sealed record Highscore : IValidatableObject
    {
        public int Id { get; set; }
        public string Playername { get; init; }
        public int Score { get; init; }
        public DateTime Date { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(this.Playername))
            {
                yield return new ValidationResult("Playername should not be null or empty", [nameof(this.Playername)]);
            }

            if (this.Score <= 0)
            {
                yield return new ValidationResult("Score should be a positive number", [nameof(this.Score)]);
            }

            if (this.Date == default)
            {
                yield return new ValidationResult("Date should be set", [nameof(this.Date)]);
            }
        }

        public bool IsValid()
        {
            return !this.Validate(new(this)).Any();
        }
    }
}
