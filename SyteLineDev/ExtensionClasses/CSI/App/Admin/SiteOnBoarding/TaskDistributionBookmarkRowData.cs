using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITaskDistributionBookmarkRowData
    {
        IRecordReadOnly GetBookmarkRowData(int origin, string tableName, string whereClause, List<string> primaryKeys);
    }

    public class TaskDistributionBookmarkRowData : ITaskDistributionBookmarkRowData
    {
        private readonly ITaskDistributionBookmarkRowDataCRUD _taskDistributionBookmarkRowDataCRUD;

        public TaskDistributionBookmarkRowData(ITaskDistributionBookmarkRowDataCRUD taskDistributionBookmarkRowDataCRUD)
        {
            _taskDistributionBookmarkRowDataCRUD = taskDistributionBookmarkRowDataCRUD;
        }

        public IRecordReadOnly GetBookmarkRowData(
            int origin,
            string tableName,
            string whereClause,
            List<string> primaryKeys)
        {
            var loadResponse = _taskDistributionBookmarkRowDataCRUD.ReadBookmarkRowData(origin, tableName, whereClause, primaryKeys);

            if (loadResponse.Items.Count == 1)
                return loadResponse.Items[0];
            else
                throw new Exception($"BookMarkRowData not one row {loadResponse.Items.Count}");
        }

    }
}