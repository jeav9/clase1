using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumnosWebApplication.Model
{
    public class Alumno
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
