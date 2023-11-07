using ForcePlatformCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp1;

namespace ForcePlatformCore.Service
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
                var users = Program.dbContext.Users.Where(c=>c.Name.Contains(keywoard) || c.Surname.Contains(keywoard) || c.MiddleName.Contains(keywoard)).ToList();
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
                var users = Program.dbContext.Users.Take(limit).ToList();
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
                var param = Program.dbContext.UserParams.Where(param=> param.UserId==userId).FirstOrDefault();
                return param;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int AddUser(User user)
        {
            try
            {
                user.CreatedDate = DateTime.Now;
                user.EditedDate = DateTime.Now;

                Program.dbContext.Add(user);
                Program.dbContext!.SaveChanges();
                return user.Id;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public int EditUser(User user)
        {
            try
            {
                user.EditedDate = DateTime.Now;

                Program.dbContext.Update(user);
                Program.dbContext!.SaveChanges();
                return user.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
