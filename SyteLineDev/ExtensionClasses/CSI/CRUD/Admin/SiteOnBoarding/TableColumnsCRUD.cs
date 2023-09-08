using CSI.Data;
using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;
using System.Linq;


namespace CSI.Admin.SiteOnBoarding
{
    public interface ITableColumnsCRUD
    {
        Dictionary<string, string> GetTableColumns(string tableName);
    }

    public class TableColumnsCRUD : ITableColumnsCRUD
    {

        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;
        private readonly IApplicationDB _applicationDB;

        public TableColumnsCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IVariableUtil variableUtil, IApplicationDB applicationDB)
        {
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _variableUtil = variableUtil;
            _applicationDB = applicationDB;
        }

        public Dictionary<string, string> GetTableColumns(string tableName)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"COLUMN_NAME_KEY", "COLUMN_NAME"},
                    {"COLUMN_NAME_VALUE", "QUOTENAME(COLUMN_NAME)"}
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "INFORMATION_SCHEMA.COLUMNS",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($@"TABLE_NAME = {_variableUtil.GetQuotedValue(tableName)};"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var response = _applicationDB.Load(request);

            return response.Items?.AsEnumerable().ToDictionary(x => x.GetValue("COLUMN_NAME_KEY").ToString(), x => x.GetValue("COLUMN_NAME_VALUE").ToString());
        }
    }
}
