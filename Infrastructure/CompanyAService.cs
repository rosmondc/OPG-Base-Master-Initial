using System.Collections.Generic;
using System.Linq;
using Helpers;
using Interfaces;
using Models;

namespace Infrastructure
{
    public  class CompanyAService : FileBaseService, ICompanyAService
    {
        public override List<FileDetail> SortFileByCompanyRule(List<string> files, int clientId)
        {
            var fileDetails = new List<FileDetail>();
            string[] formats = { "yyyy-MM-dd"};
            files.ForEach(fileInfo =>  {
                var fileDetail = BuildFileDetail(fileInfo, 10, formats);
                if (fileDetail != null)
                {
                    fileDetail.ClientId = clientId;
                    fileDetails.Add(fileDetail);
                }
            });

            return fileDetails.OrderBy(i => i.Name == "discus")
                                    .ThenBy(i => i.Name == "blaze")
                                    .ThenBy(i => i.Name == "waghor")
                                    .ThenBy(i => i.Name == "shovel")
                                    .ThenBy(i => i.FileDate).ToList();
        }
    }
}