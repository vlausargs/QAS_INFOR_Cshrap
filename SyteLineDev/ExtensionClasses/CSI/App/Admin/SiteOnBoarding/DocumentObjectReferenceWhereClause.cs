using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IDocumentObjectReferenceWhereClause
    {
        (int docTasksCount, List<string> docPrimaryKeys) GetWhereClauseCondition(long docTableRowsCount, int taskSize);
    }

    public class DocumentObjectReferenceWhereClause : IDocumentObjectReferenceWhereClause
    {
        private readonly ITmpSiteMgmtTableData _tmpSiteMgmtTableData;

        public DocumentObjectReferenceWhereClause(ITmpSiteMgmtTableData tmpSiteMgmtTableData)
        {
            _tmpSiteMgmtTableData = tmpSiteMgmtTableData;
        }

        public (int docTasksCount, List<string> docPrimaryKeys) GetWhereClauseCondition(
            long docTableRowsCount,
            int taskSize)
        {
            var tasksCount = (int)Math.Ceiling((double)docTableRowsCount / taskSize);
            var primaryKeys = _tmpSiteMgmtTableData.GetTablePrimaryKeys(nameof(MGTableName.DocumentObjectReference));
            return (tasksCount, primaryKeys);
        }
    }
}
