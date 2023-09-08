using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IDocumentObjectReferenceCRUD
    {
        long ReadRelevantDocObjectReferenceCount(string tableName);
        ICollectionLoadResponse ReadRelevantDocObjectReferenceBookmarkRowData(int origin, string tableName, string whereClause);
    }

    public class DocumentObjectReferenceCRUD : IDocumentObjectReferenceCRUD
    {
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;
        private readonly IApplicationDB _applicationDB;  
        
        public DocumentObjectReferenceCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IVariableUtil variableUtil,
            IApplicationDB applicationDB)
        {
            _collectionLoadRequestFactory = collectionLoadRequestFactory;            
            _variableUtil = variableUtil;
            _applicationDB = applicationDB;
        }

        public long ReadRelevantDocObjectReferenceCount(string tableName)
        {
            LongType docObjectReferenceCount = 0;

            var request = _collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {docObjectReferenceCount,"COUNT(1)"},
                },
                tableName: "DocumentObjectReference",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause($" INNER JOIN {tableName} t ON TableRowPointer = t.RowPointer"),
                whereClause: _collectionLoadRequestFactory.Clause($"TableName = {_variableUtil.GetQuotedValue(tableName)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            _applicationDB.Load(request);

            return docObjectReferenceCount;
        }

        public ICollectionLoadResponse ReadRelevantDocObjectReferenceBookmarkRowData(
            int origin,
            string tableName,
            string whereClause)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>
                {
                    {"DocumentObjectRowPointer", "DocumentObjectRowPointer"},
                    {"TableName", "TableName"},
                    {"TableRowPointer", "TableRowPointer"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "DocumentObjectReference",
                fromClause: _collectionLoadRequestFactory.Clause($" INNER JOIN {tableName} t ON TableRowPointer = t.RowPointer"),
                whereClause: _collectionLoadRequestFactory.Clause($"TableName = {_variableUtil.GetQuotedValue(tableName)} AND {whereClause}"),
                orderByClause: _collectionLoadRequestFactory.Clause($"DocumentObjectRowPointer,TableName,TableRowPointer OFFSET {origin} ROWS FETCH NEXT 1 ROWS ONLY"));
            return _applicationDB.Load(loadRequest);
        }

    }
}
