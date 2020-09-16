using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyChefApi.Models;

namespace MyChefApi.Data
{
    public class MyChefApiContext : DbContext
    {
        public MyChefApiContext (DbContextOptions<MyChefApiContext> options)
            : base(options)
        {
        }

        public DbSet<MyChefApi.Models.IdentityModel> IdentityModel { get; set; }
    }
}
