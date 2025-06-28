using ExamenItalika.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExamenItalika.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Escuela> Escuelas { get; set; }
		public DbSet<Profesor> Profesores { get; set; }
		public DbSet<Alumno> Alumnos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configuración de relaciones
			modelBuilder.Entity<Profesor>()
				.HasMany(p => p.Alumnos)
				.WithOne(a => a.Profesor)
				.HasForeignKey(a => a.ProfesorId);
		}
	}
}
