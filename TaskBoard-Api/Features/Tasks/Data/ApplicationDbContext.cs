﻿using Microsoft.EntityFrameworkCore;
using TaskBoard_Api.Features.Tasks.Models;

namespace TaskBoard_Api.Features.Tasks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
