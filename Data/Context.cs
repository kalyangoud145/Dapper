using CustomAuthApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthApi.Data
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }     
    }
}
