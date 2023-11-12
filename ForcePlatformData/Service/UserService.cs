﻿using ForcePlatformData;
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
                var users = AppConfig.DbContext.Users.Where(c=>c.Name.Contains(keywoard) || c.Surname.Contains(keywoard) || c.MiddleName.Contains(keywoard)).ToList();
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
                var users = AppConfig.DbContext.Users.Take(limit).ToList();
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
                var param = AppConfig.DbContext.UserParams.Where(param=> param.UserId==userId).FirstOrDefault();
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

                AppConfig.DbContext.Add(user);
                AppConfig.DbContext!.SaveChanges();
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
                AppConfig.DbContext.ChangeTracker.Clear();             
                AppConfig.DbContext.Users.Update(user);

                AppConfig.DbContext.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
