using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devChallenge.Models;
using Microsoft.EntityFrameworkCore;
using DevChallengeCarguero.Models;

namespace DevChallengeCarguero.Models
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> UserItems { get; set; }
        
        public DbSet<Address> Address { get; set; }


    }
}


