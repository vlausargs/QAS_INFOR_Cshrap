using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class ExportTaskHandler : IExportTaskHandler
    {
        private readonly ITaskDistributionCreateTaskWithWhereClause
            _taskDistributionCreateTaskWithWhereClause;

        private readonly IRelevantDataExporter _relevantDataExporter;
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;

        public ExportTaskHandler(
            ITaskDistributionCreateTaskWithWhereClause taskDistributionCreateTaskWithWhereClause,
            IRelevantDataExporter relevantDataExporter,
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD)
        {
            _taskDistributionCreateTaskWithWhereClause = taskDistributionCreateTaskWithWhereClause;
            _relevantDataExporter = relevantDataExporter;
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
        }

        public void DistributeTask(
            string site,
            int taskSize,
            string appViewName,
            int tasksCount,
            List<string> primaryKeys)
        {
            _taskDistributionCreateTaskWithWhereClause.CreateTasksOfTable(
                appViewName,
                site,
                taskSize,
                tasksCount,
                primaryKeys);

            _relevantDataExporter.CreateTaskListForRelevantTable(appViewName, site, taskSize);

            _tmpSiteMgmtTableDataCRUD.UpdateTotalTasksOfTableData(site, appViewName, tasksCount);
        }
    }
}