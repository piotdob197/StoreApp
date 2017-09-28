using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Repository.Models;

namespace StoreApp.Repository.Interfaces
{
    public interface IStoreAppContext
    {
        DbSet<UserModel> Users { get; set; }

        int SaveChanges();
        Database Database { get; }
    }
}
