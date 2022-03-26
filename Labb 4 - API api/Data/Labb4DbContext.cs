
using Labb_4___API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_4___API.Data
{
    public class Labb4DbContext : DbContext
    {
        public Labb4DbContext(DbContextOptions<Labb4DbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<WebLink> WebLink { get; set; }
    }
}
