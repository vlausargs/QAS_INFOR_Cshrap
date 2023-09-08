using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IUserDefinedFieldWhereClause
    {
        (int udfTasksCount, List<string> udfPrimaryKeys) GetWhereClauseCondition(long udfTableRowsCount, int taskSize);
    }

    public class UserDefinedFieldWhereClause : IUserDefinedFieldWhereClause
    {
        private readonly ITmpSiteMgmtTableData _tmpSiteMgmtTableData;

        public UserDefinedFieldWhereClause(ITmpSiteMgmtTableData tmpSiteMgmtTableData)
        {
            _tmpSiteMgmtTableData = tmpSiteMgmtTableData;
        }

        public (int udfTasksCount, List<string> udfPrimaryKeys) GetWhereClauseCondition(
            long udfTableRowsCount,
            int taskSize)
        {
            var tasksCount = (int)Math.Ceiling((double)udfTableRowsCount / taskSize);
            var primaryKeys = _tmpSiteMgmtTableData.GetTablePrimaryKeys(nameof(MGTableName.UserDefinedFields));
            return (tasksCount, primaryKeys);
        }
    }
}
