using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AlumnosWebApplication.Model
{
    public class AlumnoContext : DbContext
    {
        public AlumnoContext(DbContextOptions<AlumnoContext> options)
            : base(options)
        {
            
        }

        public DbSet<Alumno> Alumno { get; set; }
    }
}
