using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PartiesParticipationOblastModel
    {
        public PartiesParticipationOblast Record { get; set; }

        public string Oblasts => Record.Oblasts?.OblastName;

        public string PoliticalParties => Record.PoliticalParties?.Name;

    }
}
