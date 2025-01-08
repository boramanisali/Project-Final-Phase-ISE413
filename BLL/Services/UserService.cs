using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IUserService
    {
        public IQueryable<UserModel> Query();
        public ServiceBase Create(User record);
        public ServiceBase Update(User oblasts);
        public ServiceBase Delete(int id);
    }
    public class UserService : ServiceBase, IUserService
    {
        public UserService(Db db) : base(db)
        {
        }

        public ServiceBase Create(User record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> Query()
        {
            return _db.Users.Include(u => u.Role).OrderByDescending(u => u.IsActive).ThenBy(u => u.UserName).Select(u => new UserModel() { Record = u});
        }

        public ServiceBase Update(User oblasts)
        {
            throw new NotImplementedException();
        }
    }
}
