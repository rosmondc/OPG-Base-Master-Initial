using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface ICompanyBService
    {
        List<FileDetail> SortFileByCompanyRule(List<string> files, int clientId);
    }
}