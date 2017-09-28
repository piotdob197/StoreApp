using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreApp.Context;
using StoreApp.Repository.Interfaces;
using StoreApp.Repository.Models;

namespace StoreApp.Repository.Repository
{
    public class StoreAppRepo :IStoreAppRepo
    {
      
        private readonly IStoreAppContext _dbContext;

        public StoreAppRepo(IStoreAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel GetUser(string email)
        {
                return  _dbContext.Users.FirstOrDefault(x => x.Email == email);
        }


        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}