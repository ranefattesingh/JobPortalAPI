using Persistance.EntityFramework.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace Persistance.EntityFramework
{
    public class JobPortalContext : DbContext
    {
        public JobPortalContext(DbContextOptions<JobPortalContext> options) : base(options) { }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<JobPost> JobPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}