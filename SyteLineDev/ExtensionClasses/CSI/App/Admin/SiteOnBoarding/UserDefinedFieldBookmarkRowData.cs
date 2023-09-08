using CSI.Data.RecordSets;
using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IUserDefinedFieldBookmarkRowData
    {
        IRecordReadOnly GetRelevantUDFBookmarkRowData(int origin, string tableName, string whereClause);
    }

    public class UserDefinedFieldBookmarkRowData : IUserDefinedFieldBookmarkRowData
    {
        private readonly IUserDefinedFieldCRUD _userDefinedFieldCRUD;

        public UserDefinedFieldBookmarkRowData(IUserDefinedFieldCRUD userDefinedFieldCRUD)
        {
            _userDefinedFieldCRUD = userDefinedFieldCRUD;
        }

        public IRecordReadOnly GetRelevantUDFBookmarkRowData(
            int origin,
            string tableName,
            string whereClause)
        {
            var loadResponse = _userDefinedFieldCRUD.ReadRelevantUDFBookmarkRowData(origin, tableName, whereClause);

            if (loadResponse.Items.Count == 1)
                return loadResponse.Items[0];
            else
            {
                throw new Exception($"ReadRelevantUDFBookMarkRowData not one row {loadResponse.Items.Count}");
            }
        }
    }
}