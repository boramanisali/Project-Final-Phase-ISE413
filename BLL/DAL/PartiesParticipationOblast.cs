using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class PartiesParticipationOblast
    {
        public int Id { get; set; }

        [Required]
        public int? PartyId { get; set; }

        public PoliticalParties PoliticalParties { get; set; } //navigational property

        [Required]
        public int OblastId { get; set; }

        public Oblasts Oblasts { get; set; } //navigational property
    }
}
