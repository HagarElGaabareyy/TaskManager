using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagerApi.Models
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; } // Made nullable

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; } // Made nullable

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))] // Add this line to use JsonStringEnumConverter
        public TaskStatus Status { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum TaskStatus
    {
        NotStarted,
        Started,
        Completed
    }
}
