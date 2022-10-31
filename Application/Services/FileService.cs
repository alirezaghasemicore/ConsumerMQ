using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FileService : IFileService
    {
        public async Task WriteTextToFileAsync(string text, string path)
        {
            await File.AppendAllTextAsync(path, text);
            await File.AppendAllTextAsync(path, System.Environment.NewLine);
        }
    }
}
