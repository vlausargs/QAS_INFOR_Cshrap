using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportDataHandler
    {
        void ExportAndUpdateStatus(string site, int tasksize, string logicalFolder, string targetFileType, string taskRowpointer);
    }

    public class ExportDataHandler : IExportDataHandler
    {
        private readonly IExportProcessor _dataExporter;
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        private readonly IExportSiteTaskListener _exportSiteTaskListener;
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;

        public ExportDataHandler(IExportProcessor dataExporter,
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD,
            IExportSiteTaskListener exportSiteTaskListener,
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD)
        {
            _dataExporter = dataExporter;
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
            _exportSiteTaskListener = exportSiteTaskListener;
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
        }

        public void ExportAndUpdateStatus(string site, int tasksize, string logicalFolder, string targetFileType, string taskRowpointer)
        {
            _tmpSiteMgmtTaskCRUD.UpdateTaskStartTime(taskRowpointer, DateTime.Now);

            var finalTask = false;
            var appViewName = string.Empty;
            var tableName = string.Empty;

            try
            {
                (finalTask, appViewName, tableName) = _dataExporter.ReadFileContentAndExport(tasksize, logicalFolder, targetFileType, taskRowpointer, site);
                _exportSiteTaskListener.LogExportTaskStatusAndMsgAfterExport(taskRowpointer,true,string.Empty);
            }
            catch (Exception e)
            {
                _exportSiteTaskListener.LogExportTaskStatusAndMsgAfterExport(taskRowpointer,false,e.Message);
            }

            if (finalTask)
            {
                _tmpSiteMgmtTableDataCRUD.UpdateTableStatus(site, appViewName, TableStatus.C);
                _tmpSiteMgmtTableDataCRUD.UpdateTableLevelMinusOne(site, tableName);
            }
        }
    }
}
