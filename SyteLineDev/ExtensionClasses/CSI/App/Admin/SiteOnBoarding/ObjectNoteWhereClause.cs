using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteWhereClause
    {
        (int objectNoteTasksCount, List<string> objectNotePrimaryKeys) GetWhereClauseCondition(long objectNoteTableRowsCount, int taskSize);
    }

    public class ObjectNoteWhereClause : IObjectNoteWhereClause
    {
        private readonly ITmpSiteMgmtTableData _tmpSiteMgmtTableData;

        public ObjectNoteWhereClause(ITmpSiteMgmtTableData tmpSiteMgmtTableData)
        {
            _tmpSiteMgmtTableData = tmpSiteMgmtTableData;
        }

        public (int objectNoteTasksCount, List<string> objectNotePrimaryKeys) GetWhereClauseCondition(
            long objectNoteTableRowsCount,
            int taskSize)
        {
            var tasksCount = (int)Math.Ceiling((double)objectNoteTableRowsCount / taskSize);
            var primaryKeys = _tmpSiteMgmtTableData.GetTablePrimaryKeys(nameof(MGTableName.ObjectNotes));
            return (tasksCount, primaryKeys);
        }
    }
}
