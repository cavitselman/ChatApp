using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAppModels.Models
{
    public class GroupChat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? SenderId { get; set; }
        [Required]
        public string? Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
