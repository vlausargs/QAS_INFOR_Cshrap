using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IDocumentObjectReferenceBookmarkRowData
    {
        IRecordReadOnly GetRelevantDocObjectReferenceBookmarkRowData(int origin, string tableName, string whereClause);
    }

    public class DocumentObjectReferenceBookmarkRowData : IDocumentObjectReferenceBookmarkRowData
    {
        private readonly IDocumentObjectReferenceCRUD _documentObjectReferenceCRUD;

        public DocumentObjectReferenceBookmarkRowData(IDocumentObjectReferenceCRUD documentObjectReferenceCRUD)
        {
            _documentObjectReferenceCRUD = documentObjectReferenceCRUD;
        }

        public IRecordReadOnly GetRelevantDocObjectReferenceBookmarkRowData(
            int origin,
            string tableName,
            string whereClause)
        {
            var loadResponse = _documentObjectReferenceCRUD.ReadRelevantDocObjectReferenceBookmarkRowData(origin, tableName, whereClause);

            if (loadResponse.Items.Count == 1)
                return loadResponse.Items[0];
            else
                throw new Exception($"ReadRelevantDocObjectReferenceBookMarkRowData not one row {loadResponse.Items.Count}");
        }

    }
}