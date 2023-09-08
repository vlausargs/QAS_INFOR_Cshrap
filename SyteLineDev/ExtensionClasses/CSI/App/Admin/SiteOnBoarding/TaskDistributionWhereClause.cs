using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITaskDistributionWhereClause
    {
        (int tasksCount, List<string> primaryKeys) GetWhereClauseCondition(string tableName, string appViewName, int taskSize);
    }

    public class TaskDistributionWhereClause : ITaskDistributionWhereClause
    {
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        private readonly ITmpSiteMgmtTableData _tmpSiteMgmtTableData;

        public TaskDistributionWhereClause(ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD,
            ITmpSiteMgmtTableData tmpSiteMgmtTableData)
        {
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
            _tmpSiteMgmtTableData = tmpSiteMgmtTableData;
        }

        public (int tasksCount, List<string> primaryKeys) GetWhereClauseCondition(
            string tableName,
            string appViewName,
            int taskSize)
        {
            var tableRowsCount = _tmpSiteMgmtTableData.ReadTableDataCount(appViewName);
            var tasksCount = (int)Math.Ceiling((double)tableRowsCount / taskSize);
            var primaryKeys = _tmpSiteMgmtTableData.GetTablePrimaryKeys(tableName);
            return (tasksCount, primaryKeys);
        }
    }
}
