using Data.Providers;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DefaultLogRepository : IDefaultLogRepository
    {
        private SqlContext _sqlContext;
        public DefaultLogRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddDefaultLogToSqlServerAsync(DefaultLog defaultLog)
        {
            await _sqlContext.DefaultLogs.AddAsync(defaultLog);
        }


        public async Task SaveChangesSQlAsync()
        {
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<List<DefaultLog>> GetDefaultLogsAsync()
        {
            return await _sqlContext.DefaultLogs.OrderByDescending(dl => dl.CreateDate)
                .ToListAsync();
        }

    }
}
