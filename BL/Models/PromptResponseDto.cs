// MyProject.Core/Models/PromptDtos.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Core.Models
{
    // DTO לייצוג פרומפט מלא שחוזר ללקוח (מכיל את כל המידע)
    public class PromptResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string PromptContent { get; set; } = string.Empty; // מתאים ל-Prompt1 ב-Entity
        public string? Response { get; set; }
        public DateTime? CreatedAt { get; set; }

        public string CategoryName { get; set; } = string.Empty;
        public string SubCategoryName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty; 
    }

    public class CreatePromptRequestDto
    {
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "SubCategory ID is required.")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "Prompt content is required.")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Prompt must be between 1 and 1000 characters.")]
        public string PromptContent { get; set; } = string.Empty;
    }
}