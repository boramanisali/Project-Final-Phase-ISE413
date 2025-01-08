using BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RayonsModel
    {
        public Rayons Record { get; set; }

        [DisplayName("Rayon")]
        public string Name => Record.Name;

        [DisplayName("Voter Population")]
        public string VoterNumber => Record.VoterNumber.ToString();

        public string Oblasts => Record.Oblasts?.OblastName;


    }
}
