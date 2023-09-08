using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportTaskHandler
    {
        (bool isSuccess, string errorMsg) DistributeTask(
            string site,
            string logicalFolder,
            string fileSpec,
            string serverName,
            List<Dictionary<string, string>> fileInfoList);

        void ProcessTask(
            byte[] fileContent,
            string site,
            string tableName,
            int? tableLevel,
            string taskRowPointer,
            TaskType taskType);
    }
}