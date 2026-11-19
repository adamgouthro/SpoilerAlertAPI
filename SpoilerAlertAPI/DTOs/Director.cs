using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SpoilerAlertAPI.DTOs
{
    public class Director
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        [Required]
        public string Birthplace { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
