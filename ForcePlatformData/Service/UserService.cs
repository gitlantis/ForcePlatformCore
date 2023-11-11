using ForcePlatformData;
using ForcePlatformData.DbModels;

namespace ForcePlatformData.Service
{
    public class UserService
    {
        public UserService()
        {
        }

        public List<User> FindUser(string keywoard)
        {
            try
            {
                var users = AppConfig.dbContext.Users.Where(c=>c.Name.Contains(keywoard) || c.Surname.Contains(keywoard) || c.MiddleName.Contains(keywoard)).ToList();
                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> TakeSome(int limit)
        {
            try
            {
                var users = AppConfig.dbContext.Users.Take(limit).ToList();
                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserParams TakeUserParams(int userId)
        {
            try
            {
                var param = AppConfig.dbContext.UserParams.Where(param=> param.UserId==userId).FirstOrDefault();
                return param;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User AddUser(User user)
        {
            try
            {
                user.CreatedDate = DateTime.Now;
                user.EditedDate = DateTime.Now;

                AppConfig.dbContext.Add(user);
                AppConfig.dbContext!.SaveChanges();
                return user;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public User EditUser(User user)
        {
            try
            {
                user.EditedDate = DateTime.Now;
                AppConfig.dbContext.ChangeTracker.Clear();             
                AppConfig.dbContext.Users.Update(user);

                AppConfig.dbContext.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
