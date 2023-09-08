using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IUserDefinedFieldCRUD
    {
        long ReadRelevantUDFCount(string tableName);
        ICollectionLoadResponse ReadRelevantUDFBookmarkRowData(int origin, string tableName, string whereClause);
    }

    public class UserDefinedFieldCRUD : IUserDefinedFieldCRUD
    {
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;
        private readonly IApplicationDB _applicationDB;

        public UserDefinedFieldCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IVariableUtil variableUtil,
            IApplicationDB applicationDB)
        {
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _variableUtil = variableUtil;
            _applicationDB = applicationDB;
        }

        public long ReadRelevantUDFCount(string tableName)
        {
            LongType userDefinedFieldCount = 0;

            var request = _collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {userDefinedFieldCount,"COUNT(1)"},
                },
                tableName: "UserDefinedFields",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause($" INNER JOIN {tableName} t ON t.RowPointer = UserDefinedFields.RowId"),
                whereClause: _collectionLoadRequestFactory.Clause($"TableName = {_variableUtil.GetQuotedValue(tableName)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            _applicationDB.Load(request);

            return userDefinedFieldCount;
        }

        public ICollectionLoadResponse ReadRelevantUDFBookmarkRowData(
            int origin,
            string tableName,
            string whereClause)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>
                {
                    {"RowId", "RowId"},
                    {"TableName", "TableName"}
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "UserDefinedFields",
                fromClause: _collectionLoadRequestFactory.Clause($" INNER JOIN {tableName} t ON t.RowPointer = UserDefinedFields.RowId"),
                whereClause: _collectionLoadRequestFactory.Clause($"{whereClause}"),
                orderByClause: _collectionLoadRequestFactory.Clause($"RowId,TableName OFFSET {origin} ROWS FETCH NEXT 1 ROWS ONLY"));
            return _applicationDB.Load(loadRequest);
        }

    }
}
