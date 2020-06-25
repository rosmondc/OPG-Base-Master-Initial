using System.Collections.Generic;
using System.Linq;
using Helpers;
using Interfaces;
using Models;

namespace Infrastructure
{
    public  class CompanyBService : FileBaseService, ICompanyBService
    {
        public override List<FileDetail> SortFileByCompanyRule(List<string> files, int clientId)
        {
            var fileDetails = new List<FileDetail>();
            string[] formats = { "yyyyMMdd"};
            files.ForEach(fileInfo =>  {
                var fileDetail = BuildFileDetail(fileInfo, 8, formats);
                if (fileDetail != null)
                {
                    fileDetail.ClientId = clientId;
                    fileDetails.Add(fileDetail);
                }
            });

            return fileDetails.OrderBy(i => i.Name == "talon")
                        .ThenBy(i => i.Name == "eclair")
                        .ThenBy(i => i.Name == "widget")
                        .ThenBy(i => i.Name == "orca")
                        .ThenBy(i => i.FileDate).ToList();
        }
    }
}