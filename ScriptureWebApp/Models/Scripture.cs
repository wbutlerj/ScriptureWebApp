using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScriptureWebApp.Models
{
    public class Scripture
    {
        public int ScriptureID { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string Notes { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string Book { get; set; }

        [RegularExpression(@"^[0-9]+$")]
        [Required]
        [StringLength(30)]
        public string Chapter { get; set; }

        [RegularExpression(@"^[0-9]+$")]
        [Required]
        [StringLength(30)]
        public string Verse { get; set; }
    }
}
