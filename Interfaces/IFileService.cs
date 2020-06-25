using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models;

namespace Interfaces
{
    public interface IFileService
    {
         List<FileDetail> ProcessOrderFile(IConfiguration config);
    }
}