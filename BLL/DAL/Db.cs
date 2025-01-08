using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<PoliticalParties> PoliticalParties { get; set; }

        public DbSet<Oblasts> Oblasts { get; set; }

        public DbSet<Rayons> Rayons { get; set; }

        public DbSet<PartiesParticipationOblast> Participations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
            
        }
    }
}
