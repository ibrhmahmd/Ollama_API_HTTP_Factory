using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    // Entity Model for Session Table
    public class Session
    {
        [Key]
        public string Id { get; set; } // Primary Key

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? EndedAt { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public string UserId { get; set; } // Foreign Key

        [StringLength(1000)]
        public string SystemMessage { get; set; } // Lookup Table Reference

        // Foreign Key for AIModel relationship
        [Required]
        public string AIModelId { get; set; } // Foreign Key property as a string (assuming it's a reference to another table)

        [ForeignKey("AIModelId")]
        public AIModel AIModel { get; set; } // Navigation property to AIModel (the related entity)

        // Navigation property for the related AIResponses (One-to-Many)
        public List<AIResponse> AiResponses { get; set; }

        // Navigation property for the related Prompts (One-to-Many)
        public List<Prompt> Prompts { get; set; }
    }
}