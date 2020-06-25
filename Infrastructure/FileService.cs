using System.Linq;
using System;
using System.Collections.Generic;
using Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Interfaces;

namespace Infrastructure
{
    public class FileService : IFileService
    {
        private readonly ICompanyAService _companyAService;
        private readonly ICompanyBService _companyBService;
        public FileService(ICompanyAService companyAService, ICompanyBService companyBService)
        {
            _companyAService = companyAService;
            _companyBService = companyBService;
        }

        public  List<FileDetail> ProcessOrderFile(IConfiguration config)
        {
            var paths = config.GetSection("ClientSettings").Get<List<ClientFile>>();
            var fileDetails = new List<FileDetail>();

            paths.ForEach(clientFile =>  {
                var files = Directory.EnumerateFiles(clientFile.FileDirectoryPath).ToList();
                var companyId = clientFile.ClientId;
                if(clientFile.ClientId == 1001)
                {
                    fileDetails.AddRange(_companyAService.SortFileByCompanyRule(files, companyId));
                }
                else
                {
                    fileDetails.AddRange(_companyBService.SortFileByCompanyRule(files, companyId));
                }
            });

            return fileDetails;
        }
    }
}

