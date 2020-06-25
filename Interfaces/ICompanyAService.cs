using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface ICompanyAService
    {
        List<FileDetail> SortFileByCompanyRule(List<string> files, int clientId);
    }
}