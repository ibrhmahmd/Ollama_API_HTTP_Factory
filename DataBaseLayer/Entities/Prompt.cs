using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    public class Prompt
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [ForeignKey("SessionId")]
        [Required]
        public string SessionId { get; set; }

        [MaxLength(10)]
        public string? Tempreture { get; set; }
    }
}
