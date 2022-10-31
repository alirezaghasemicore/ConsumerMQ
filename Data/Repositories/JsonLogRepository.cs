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
    public class JsonLogRepository : IJsonLogRepository
    {
        private SqlContext _sqlContext;
        public JsonLogRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddJsonLogToSqlServerAsync(JsonLog jsonLog)
        {
            await _sqlContext.JsonLogs.AddAsync(jsonLog);
        }

        public async Task<List<JsonLog>> GetJsonLogs()
        {
            return await _sqlContext.JsonLogs.OrderByDescending(jl => jl.JsonId)
                .ToListAsync();
        }
    }
}
