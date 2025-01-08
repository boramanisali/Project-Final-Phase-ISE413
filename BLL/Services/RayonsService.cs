using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    
        public interface IRayonsService
        {
            public IQueryable<RayonsModel> Query();
            public ServiceBase Create(Rayons record);
            public ServiceBase Update(Rayons rayons);
            public ServiceBase Delete(int id);
        }

        public class RayonsService : ServiceBase, IRayonsService
        {
            public RayonsService(Db db) : base(db)
            {
            }
            public IQueryable<RayonsModel> Query()
            {
                return _db.Rayons.OrderBy(r => r.Name).Select(r => new RayonsModel() { Record = r });
            }
            public ServiceBase Create(Rayons record)
            {
                if (_db.Rayons.Any(r => r.Name.ToUpper() == record.Name.ToUpper().Trim()))
                    return Error("This rayon is existing in the system!");
                record.Name = record.Name?.Trim();
                _db.Rayons.Add(record);
                _db.SaveChanges();
                return Success("Rayon is registered to elections successfuly !");
            }

            //It was rayons before record
            public ServiceBase Update(Rayons record)
            {
                if (_db.Rayons.Any(r => r.Id != record.Id && r.Name.ToUpper() == r.Name.ToUpper().Trim()))
                    return Error("This rayon is existing in the system!");
                var entity = _db.Rayons.Find(record.Id);
                entity.Name = record.Name?.Trim();
                entity.VoterNumber = record.VoterNumber;
                entity.OblastId = record.OblastId;
                _db.Rayons.Update(entity);
                _db.SaveChanges();
                return Success("The rayon with deputy number is updated to the system");
            }
            public ServiceBase Delete(int id)
            {
                var entity = _db.Rayons.SingleOrDefault(r => r.Id == id);
                if (entity is null)
                    return Error("Rayon is not found at our system!");
                _db.Rayons.Remove(entity);
                _db.SaveChanges();
                return Success("The oblast with deputy number is deleted from the system");
            }
        }
}
