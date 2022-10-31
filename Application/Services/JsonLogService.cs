using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JsonLogService : IJsonLogService
    {
        private IJsonLogRepository _jsonLogRepository;
        public JsonLogService(IJsonLogRepository jsonLogRepository)
        {
            _jsonLogRepository = jsonLogRepository;
        }

        public async Task AddJsonLogToSqlServerAsync(JsonLog jsonLog)
        {
            await _jsonLogRepository.AddJsonLogToSqlServerAsync(jsonLog);
        }

        public async Task<List<JsonLog>> GetJsonLogs()
        {
            return await _jsonLogRepository.GetJsonLogs();
        }
    }
}
