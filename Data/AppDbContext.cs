using System;
using ApiAlumnos.Models;
using Microsoft.EntityFrameworkCore;

namespace IDGS902.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
    }
}
