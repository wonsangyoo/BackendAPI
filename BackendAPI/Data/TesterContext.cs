using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Data
{
    public class TesterContext: DbContext
    {
        public TesterContext(DbContextOptions<TesterContext> option): base(option)
        {

        }

        public DbSet<Test> Tests { get; set; }
    }
}
