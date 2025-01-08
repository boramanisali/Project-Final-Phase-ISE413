using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Oblasts
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string OblastName { get; set; }

        public int DeputyNumber { get; set; }

        public List<Rayons> Rayons { get; set; } = new List<Rayons>();

        public List<PartiesParticipationOblast> Parties { get; set; } = new List<PartiesParticipationOblast>();
    }
}
