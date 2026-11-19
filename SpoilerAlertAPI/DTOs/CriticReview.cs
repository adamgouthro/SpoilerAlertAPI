using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SpoilerAlertAPI.DTOs
{
    public class CriticReview
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public string Description { get; set; } = string.Empty; 

        public int Rating { get; set; } 
        public bool IsPublished { get; set; }

        public string CreatedBy { get; set; } = string.Empty; 

        public DateTime CreatedDate { get; set; }

        public UserSnapshot UserSnapshot { get; set; } = null!;

    
    }
}
