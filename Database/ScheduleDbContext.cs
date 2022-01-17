using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_nt1.Models;

namespace tp_nt1.Database
{
    public class ScheduleDbContext : DbContext
    {
        #region Constructor

        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
        {

        }

        #endregion


        #region Properties

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalService> MedicalServices { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Form> Forms { get; set; }

        #endregion
    }
}
