using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreApp.Repository.Models;

namespace StoreApp.Repository.Interfaces
{
    public interface IStoreAppRepo
    {
        UserModel GetUser(string email);
        void SaveChanges();
    }
}