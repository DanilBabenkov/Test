using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend5.Models.ViewModels
{
    public class ProstoBDCreateModel
    {
        public Int32 Number { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [MaxLength(200)]
        public String Text { get; set; }
    }
}
