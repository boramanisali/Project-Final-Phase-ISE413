using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class PoliticalParties
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal LastPercentage { get; set; }

        public DateTime RegDate { get; set; }

        public List<PartiesParticipationOblast> OblastParticipation { get; set; } = new List<PartiesParticipationOblast>();
    }
}
