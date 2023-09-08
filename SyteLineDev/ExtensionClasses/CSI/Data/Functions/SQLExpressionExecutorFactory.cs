using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class SQLExpressionExecutorFactory
    {
        public ISQLExpressionExecutor Create(IApplicationDB appDB, IParameterProvider parameterProvider)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);

            return new SQLExpressionExecutor(appDB, null, null, queryLanguage);
        }
        public ISQLCollectionLoad Create(IApplicationDB appDB)
        {
            var dataTypeUtil = new DataTypeUtil();
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

            return new SQLExpressionExecutor(appDB, dataTypeUtil, dataTableToCollectionLoadResponse, null);
        }
    }
}
