using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    public class AIModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Size { get; set; }

        [MaxLength(100)]
        public string Digest { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Version { get; set; }

        [MaxLength(50)]
        public string Format { get; set; }

        [MaxLength(50)]
        public string ParameterSize { get; set; }

        [MaxLength(50)]
        public string QuantizationLevel { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

        [Required]
        public bool IsArchieved { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        // Navigation property for the related Sessions (One-to-Many)
        public List<Session> Sessions{ get; set; }
    }
}