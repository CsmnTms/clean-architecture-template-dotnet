using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CleanArch.Core.ToDoListAggregate;

namespace CleanArch.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ToDoList> ToDoLists => Set<ToDoList>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // TODO_research: see what this does
    }
}
