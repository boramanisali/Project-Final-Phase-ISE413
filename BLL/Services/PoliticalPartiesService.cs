using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IPoliticalPartiesService
    {
        public IQueryable<PoliticalPartiesModel> Query();

        public ServiceBase Create(PoliticalParties record);

        public ServiceBase Update(PoliticalParties record);

        public ServiceBase Delete(int id);
    }
    public class PoliticalPartiesService : ServiceBase , IPoliticalPartiesService
    {
        public PoliticalPartiesService(Db db) : base(db)
        {
        }

        public ServiceBase Create(PoliticalParties record)
        {
            if (_db.PoliticalParties.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("This political party is existing in the system!");
            record.Name = record.Name?.Trim();
            //record.OblastParticipation = record.OblastParticipation;
            _db.PoliticalParties.Add(record);
            _db.SaveChanges();
            return Success("Political Party is registered to elections successfuly !");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.PoliticalParties.Include(s => s.OblastParticipation).SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return Error("Political Party is not found at our system!");
            if (entity.OblastParticipation.Any())
                return Error("Political Party is attending at least in one oblast! ");
            _db.Participations.RemoveRange(entity.OblastParticipation);
            _db.PoliticalParties.Remove(entity);
            _db.SaveChanges();
            return Success("Political Party is deleted from attendence list for elections !");
        }

        public IQueryable<PoliticalPartiesModel> Query()
        {
            return _db.PoliticalParties.Include(s=>s.OblastParticipation).ThenInclude(op => op.Oblasts).OrderBy(s => s.Name).Select(s => new PoliticalPartiesModel() {Record = s});
        }

        //It was written politicalparties before record
        public ServiceBase Update(PoliticalParties record)
        {
            if (_db.PoliticalParties.Any(s => s.Id !=record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("This political party is existing in the system!");
            var entity = _db.PoliticalParties.Include(p => p.OblastParticipation).SingleOrDefault(s => s.Id == record.Id);
            if (entity is null)
                return Error("Political Party is not found at our system!");
            _db.Participations.RemoveRange(entity.OblastParticipation);
            entity.Name = record.Name?.Trim();
            entity.LastPercentage = record.LastPercentage;
            entity.RegDate = record.RegDate;
            entity.OblastParticipation = record.OblastParticipation;
            _db.PoliticalParties.Update(entity);
            _db.SaveChanges();
            return Success("Political Party is registered to elections successfuly !");
        }
    }
}
