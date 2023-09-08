using System;

namespace CSI.Admin.SiteOnBoarding
{
    public class TableStatusHandler : ITableStatusHandler
    {
        private readonly IFileInfoHandler _fileInfoHandler;
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;

        public TableStatusHandler(
            IFileInfoHandler fileInfoHandler,
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD)
        {
            _fileInfoHandler = fileInfoHandler;
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
        }

        public void UpdateTableStatusToComplete(
            string site,
            string taskFileName,
            int? totalTasks,
            string tableName)
        {
            var fileInfo = _fileInfoHandler.SettleFileName(taskFileName);

            if (totalTasks == Convert.ToInt32(fileInfo["TotalTasks"]) - 1)
                _tmpSiteMgmtTableDataCRUD.UpdateTableStatus(site, tableName, TableStatus.C);

            _tmpSiteMgmtTableDataCRUD.UpdateTableTotalTasksPlusOne(site, tableName);
        }

        public void UpdateTableLevelMinusOne(string site, string tableName)
        {
            _tmpSiteMgmtTableDataCRUD.UpdateTableLevelMinusOne(site, tableName);
        }

        public (int PendingCount, int InProgressCount, int FailedCount) GetTableStateInfo(
            string site)
        {
            var tableStateLoadResponse = _tmpSiteMgmtTableDataCRUD.ReadTableStateInfo(site);
            var pendingCount = 0;
            var inProgressCount = 1;
            var failedCount = 0;

            if (tableStateLoadResponse.Items.Count == 1)
            {
                pendingCount = tableStateLoadResponse.Items[0].GetValue<int>("pendingCount");
                inProgressCount = tableStateLoadResponse.Items[0].GetValue<int>("inProgressCount");
                failedCount = tableStateLoadResponse.Items[0].GetValue<int>("failedCount");
            }

            return (pendingCount, inProgressCount, failedCount);
        }
    }
}