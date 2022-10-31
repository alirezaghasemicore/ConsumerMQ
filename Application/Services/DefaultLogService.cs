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
    public class DefaultLogService : IDefaultLogService
    {
        private IDefaultLogRepository _defaultLogRepository;
        public DefaultLogService(IDefaultLogRepository defaultLogRepository)
        {
            _defaultLogRepository = defaultLogRepository;
        }

        public async Task AddDefaultLogToSqlServerAsync(DefaultLog defaultLog)
        {
            await _defaultLogRepository.AddDefaultLogToSqlServerAsync(defaultLog);
        }



        public async Task SaveChangesSQlAsync()
        {
            await _defaultLogRepository.SaveChangesSQlAsync();
        }

        public async Task<List<DefaultLog>> GetDefaultLogsAsync()
        {
            return await _defaultLogRepository.GetDefaultLogsAsync();
        }
    }
}
