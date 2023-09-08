using CSI.Data;
using CSI.Data.CRUD;
using System;


namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportTask
    {
        (bool IsExist, string TableName, string RowPointer, TableStatus TableStatus) GetAvailableExportTask(string site);
    }

    public class ExportTask : IExportTask
    {
        private readonly IDateTimeUtil _dateTimeUtil;
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;

        public ExportTask(IDateTimeUtil dateTimeUtil,
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD)
        {
            _dateTimeUtil = dateTimeUtil;
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
        }

        public (bool IsExist, string TableName, string RowPointer, TableStatus TableStatus) GetAvailableExportTask(string site)
        {
            ICollectionLoadResponse taskLoadResponse = _tmpSiteMgmtTaskCRUD.ReadAvailableTask(site);

            if (taskLoadResponse.Items.Count == 0)
                return (false, string.Empty, string.Empty, TableStatus.None);

            string tableName = taskLoadResponse.Items[0].GetValue<string>("tableName");
            string rowPointer = taskLoadResponse.Items[0].GetValue<string>("rowPointer");
            string tableStatus = taskLoadResponse.Items[0].GetValue<string>("tableStatus");
            int? taskType = taskLoadResponse.Items[0].GetValue<int?>("taskType");

            if (taskType == null)
                return (false, string.Empty, string.Empty, TableStatus.None);

            return (true, tableName, rowPointer, (TableStatus)Enum.Parse(typeof(TableStatus), tableStatus));
        }
    }
}
