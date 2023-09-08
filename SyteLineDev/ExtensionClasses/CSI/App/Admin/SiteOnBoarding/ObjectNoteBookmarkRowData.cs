using CSI.Data.RecordSets;
using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteBookmarkRowData
    {
        IRecordReadOnly GetRelevantObjectNotesBookmarkRowData(int origin, string tableName, string whereClause);
    }

    public class ObjectNoteBookmarkRowData : IObjectNoteBookmarkRowData
    {
        private readonly IObjectNoteCRUD _objectNoteCRUD;

        public ObjectNoteBookmarkRowData(IObjectNoteCRUD objectNoteCRUD)
        {
            _objectNoteCRUD = objectNoteCRUD;
        }

        public IRecordReadOnly GetRelevantObjectNotesBookmarkRowData(
            int origin,
            string tableName,
            string whereClause)
        {
            var loadResponse = _objectNoteCRUD.ReadRelevantObjectNotesBookmarkRowData(origin, tableName, whereClause);

            if (loadResponse.Items.Count == 1)
                return loadResponse.Items[0];
            else
            {
                throw new Exception($"ReadRelevantObjectNotesBookMarkRowData not one row {loadResponse.Items.Count}");
            }
        }
    }
}
