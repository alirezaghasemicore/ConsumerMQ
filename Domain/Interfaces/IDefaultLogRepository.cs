using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDefaultLogRepository
    {
        Task AddDefaultLogToSqlServerAsync(DefaultLog defaultLog);

        Task SaveChangesSQlAsync();

        Task<List<DefaultLog>> GetDefaultLogsAsync();
    }
}
