using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend5.Models
{
    public class ProstoBD
    {
        public Int32 Id { get; set; }

        public Int32 Number { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [MaxLength(200)]
        public String Text { get; set; }

    }
}
