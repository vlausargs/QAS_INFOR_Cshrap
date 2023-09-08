using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportTaskHandler
    {
        void DistributeTask(
            string site,
            int taskSize,
            string appViewName,
            int tasksCount,
            List<string> primaryKeys);
    }
}