using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MasterTimesContext.Models;

namespace MasterTimesContext.Data
{
    public class MasterTimesContext : DbContext
    {
        public MasterTimesContext(DbContextOptions<MasterTimesContext> options)
            : base(options)
        {
        }

        public DbSet<global::MasterTimesContext.Models.TimeViewModel> TimeViewModel { get; set; }
    }
}
