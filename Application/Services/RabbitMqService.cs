using Application.Interfaces;
using Domain.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private IDefaultLogService _defaultLogService;
        private IFileService _fileService;
        private IJsonLogService _jsonLogService;
        public RabbitMqService(IDefaultLogService defaultLogService, IFileService fileService, IJsonLogService jsonLogService)
        {
            _defaultLogService = defaultLogService;
            _fileService = fileService;
            _jsonLogService = jsonLogService;
        }


        public void ReadingData()
        {
            Domain.ViewModels.RabbitMQ_ViewModel rabbitMQ = new Domain.ViewModels.RabbitMQ_ViewModel();
            rabbitMQ.User_Name = "guest";
            rabbitMQ.Host_Name = "localhost";
            rabbitMQ.Password = "guest";
            var factory = new ConnectionFactory() { HostName = rabbitMQ.Host_Name };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "inbox",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = ConvertToUtf8(body);
                    Domain.Models.DefaultLog defaultLog = new Domain.Models.DefaultLog();
                    defaultLog.Message = message;
                    defaultLog.Redelivered = ea.Redelivered;
                    defaultLog.Exchange = ea.Exchange;
                    defaultLog.Routing_Key = ea.RoutingKey;
                    string jsonText = ToJson(ea);
                    JsonLog jsonLog = new JsonLog();
                    jsonLog.LogText = jsonText;
                    await _jsonLogService.AddJsonLogToSqlServerAsync(jsonLog);
                    await _defaultLogService.AddDefaultLogToSqlServerAsync(defaultLog);
                    await _defaultLogService.SaveChangesSQlAsync();
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "inbox",
                                     autoAck: true,
                                     consumer: consumer);

                Console.ReadLine();
            }
        }

        public string ToJson(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public string ConvertToUtf8(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
