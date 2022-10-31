using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        #region Models

        public DbSet<DefaultLog> DefaultLogs { get; set; }

        public DbSet<JsonLog> JsonLogs { get; set; }
        #endregion
    }
}
