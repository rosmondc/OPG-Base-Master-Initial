using System.Linq;
using Infrastructure;
using Xunit;

namespace opg_201910Base_master.BaseMasterTests
{
    public class CompanyAServiceTests
    {
        [Theory]
        [InlineData(new object[] { new string[] {
            "UploadFiles/ClientA\\blaze-2018-05-01.xml"
            , "UploadFiles/ClientA\\blaze-2019-01-23.xml"
            , "UploadFiles/ClientA\\discus-2015-12-16.xml"
            , "UploadFiles/ClientA\\eclair_20180908.xml"
            , "UploadFiles/ClientA\\shovel-2000-01-01.xml"
            , "UploadFiles/ClientA\\waghor-2012-06-20.xml"} })]
        public void GetFilesFromCompanyAThenRemoveFileInvalidDateFormat(string[] files)
        {
            var service = new CompanyAService();
            var results = service.SortFileByCompanyRule(files.ToList(), 1001);
            Assert.Equal(results.Count(), 5);
        }

        [Theory]
        [InlineData(new object[] { new string[] {
           "UploadFiles/ClientB\\blaze-2019-01-23.xml"
            , "UploadFiles/ClientB\\eclair_20180908.xml"
            , "UploadFiles/ClientB\\orca_20130219.xml"
            , "UploadFiles/ClientB\\orca_20170916.xml"
            , "UploadFiles/ClientB\\talon_20150831.xml"
            , "UploadFiles/ClientB\\widget_2019-01-23.xml"
            , "UploadFiles/ClientB\\eclair_2019-09-23.xml"
            , "UploadFiles/ClientB\\eclair_2019-12-12.xml"
           } })]
        public void GetFilesFromCompanyBThenRemoveFileInvalidDateFormat(string[] files)
        {
            var service = new CompanyBService();
            var results = service.SortFileByCompanyRule(files.ToList(), 2001);
            Assert.Equal(results.Count(), 4);
        }

    }
}