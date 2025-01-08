using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Rayons
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int VoterNumber { get; set; }

        [Required]
        public int OblastId { get; set; }

        public Oblasts Oblasts { get; set; } //navigational property
    }
}
