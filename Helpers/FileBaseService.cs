using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Interfaces;
using Models;

namespace Helpers
{
    public abstract class FileBaseService
    {
        public abstract List<FileDetail> SortFileByCompanyRule(List<string> files, int clientId);

        public FileDetail BuildFileDetail(string fileInfo, int dateLength, string[] format)
        {
            var fileDetail = new FileDetail();
            var fileName = Path.GetFileNameWithoutExtension(fileInfo);
            fileDetail.Name = StringExtensions.Prefix(Path.GetFileNameWithoutExtension(fileName), fileName.Length, dateLength + 1);
            fileDetail.ClientId = fileDetail.Name.FirstOrDefault();

            if(DateExtensions.IsValidDate(fileName.Substring(fileName.Length - dateLength), format))
            {
                fileDetail.FileDate = DateTime.ParseExact(fileName.Substring(fileName.Length - dateLength)
                                 , format, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
                return null;

            return fileDetail;
        }
    }
}