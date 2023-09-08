using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportSiteTaskListener
    {
        (bool isSuccess, string errorMsg) ProcessAfterFinish(string site);
        
        void LogExportTaskStatusAndMsgAfterExport(string rowPointer, bool isSuccss, string errorMsg);
    }

    public class ExportSiteTaskListener : IExportSiteTaskListener
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        private readonly IStatusHandler _statusHandler;

        public ExportSiteTaskListener(
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD,
            IStatusHandler statusHandler)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
            _statusHandler = statusHandler;
        }

        public void LogExportTaskStatusAndMsgAfterExport(string rowPointer, bool isSuccss, string errorMsg)
        {
            _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(rowPointer, isSuccss? TaskStatus.C:TaskStatus.F, errorMsg);
            _tmpSiteMgmtTaskCRUD.UpdateTaskEndTime(rowPointer, DateTime.Now);
        }

        public (bool isSuccess, string errorMsg) ProcessAfterFinish(string site)
        {
            if (_tmpSiteMgmtTaskCRUD.ReadExistTask(site) ||
                _tmpSiteMgmtTableDataCRUD.ReadExistInProgressTable(site))
                return (true, string.Empty);

            _statusHandler.ChangeStateAfterFinished(site);

            return (false, string.Empty);
        }
    }
}