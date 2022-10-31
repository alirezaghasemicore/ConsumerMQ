using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRabbitMqService
    {
        void ReadingData();
        string ToJson(object data);
        string ConvertToUtf8(byte[] bytes);
    }
}
