using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJsonLogService
    {
        Task AddJsonLogToSqlServerAsync(JsonLog jsonLog);

        Task<List<JsonLog>> GetJsonLogs();
    }
}
