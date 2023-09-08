using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ISiteExportTaskDistributor
    {
        (bool isSuccess, string errorMsg) DistributeTask(string site, int taskSize);
    }

    public class SiteExportTaskDistributor : ISiteExportTaskDistributor
    {
        private readonly IPendingTable _iPendingTable;
        private readonly ITaskDistributionWhereClause _taskDistributionWhereClause;
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        private readonly IExportSiteTaskListener _exportSiteTaskListener;
        private readonly IExportTaskHandler _exportTaskHandler;

        public SiteExportTaskDistributor(
            IPendingTable iPendingTable,
            ITaskDistributionWhereClause taskDistributionWhereClause,
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD,
            IExportSiteTaskListener exportSiteTaskListener,
            IExportTaskHandler exportTaskHandler)
        {
            _iPendingTable = iPendingTable;
            _taskDistributionWhereClause = taskDistributionWhereClause;
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
            _exportSiteTaskListener = exportSiteTaskListener;
            _exportTaskHandler = exportTaskHandler;
        }

        public (bool isSuccess, string errorMsg) DistributeTask(
            string site,
            int taskSize)
        {
            var (tableName, appViewName) = _iPendingTable.ReadPendingTableInfo(site);

            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(appViewName))
            {
                return _exportSiteTaskListener.ProcessAfterFinish(site);
            }

            (int tasksCount, List<string> primaryKeys) =
                _taskDistributionWhereClause.GetWhereClauseCondition(
                    tableName,
                    appViewName,
                    taskSize);

            if (tasksCount == 0)
            {
                _tmpSiteMgmtTableDataCRUD.UpdateTableStatus(site, appViewName, TableStatus.C);
                _tmpSiteMgmtTableDataCRUD.UpdateTableLevelMinusOne(site, tableName);
                return (true, string.Empty);
            }

            _exportTaskHandler.DistributeTask(
                site,
                taskSize,
                appViewName,
                tasksCount,
                primaryKeys);

            return (true, string.Empty);
        }
    }
}