using BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OblastsModel
    {
        public Oblasts Record { get; set; }

        [DisplayName("Oblast")]
        public string OblastName => Record.OblastName;

        [DisplayName("Deputats-Halkvekili")]
        public string DeputyNumber => Record.DeputyNumber.ToString();

        public string PoliticalParties => string.Join("<br>", Record.Parties.Select(po => po.PoliticalParties?.Name));

        [DisplayName("Parties")]
        public List<int?> PoliticalPartyIds
        {
            get => Record.Parties?.Select(po => po.PartyId).ToList();
            set => Record.Parties = value.Select(q => new PartiesParticipationOblast() { OblastId = (int)q }).ToList();
        }
        
    }
}
