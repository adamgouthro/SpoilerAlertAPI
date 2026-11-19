using SpoilerAlertAPI.DTOs;
using System.Text.Json.Serialization;

namespace SpoilerAlertAPI.Models
{
    public class SpoilerAlert
    {

        public int Id { get; set; }

        public string Synopsis { get; set; } = string.Empty;

        public int RunTime { get; set; }
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime ReleaseDate { get; set; }


        public Genre Genre { get; set; } = null!;

        public AudienceRating AudienceRating { get; set; } = null!;

        public Director Director { get; set; } = null!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CriticReview> CriticReview { get; set; } = null!;

    }
}
