using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    public class SystemMessage // Lookup table
    {
        [Key]
        [StringLength(1000)]
        public string Content { get; set; }
    }
}
