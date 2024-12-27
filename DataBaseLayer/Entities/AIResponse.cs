using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    public class AIResponse
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }

        [ForeignKey("SessionId")]
        [Required]
        public Session SessionID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [MaxLength(50)]
        public string TotalDuration { get; set; }

        [MaxLength(50)]
        public string LoadDuration { get; set; }

        [MaxLength(50)]
        public string PromptEvalCount { get; set; }

        [MaxLength(50)]
        public string PromptEvalDuration { get; set; }

        [MaxLength(50)]
        public string EvalDuration { get; set; }
    }
}
