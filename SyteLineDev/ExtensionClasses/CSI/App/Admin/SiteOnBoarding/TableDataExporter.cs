using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITableDataExporter
    {
        (bool isSuccess, string errorMsg) ProcessAndUpdateTaskStatusIfFailed(string site, int taskSize, string targetFileType, string logicalFolder, string taskRowPointer);
    }

    public class TableDataExporter : ITableDataExporter
    {
        private readonly IExportDataHandler _exportDataHandler;

        public TableDataExporter(IExportDataHandler exportDataHandler, ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD)
        {
            _exportDataHandler = exportDataHandler;
        }

        public (bool isSuccess, string errorMsg) ProcessAndUpdateTaskStatusIfFailed(string site, int taskSize, string targetFileType, string logicalFolder, string taskRowPointer)
        {
            _exportDataHandler.ExportAndUpdateStatus(site, taskSize, logicalFolder, targetFileType.ToUpper(), taskRowPointer);
          
            return (true, string.Empty);
        }
    }
}
