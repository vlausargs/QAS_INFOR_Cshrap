using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionLoadArbitrary : ICollectionLoadStatement
    {
        readonly IQueryLanguage queryLanguage;
        readonly ISQLCollectionLoadProcess sqlCollectionLoadProcess;
        readonly ITriggerManagement triggerManagement;

        public SQLCollectionLoadArbitrary(
            IQueryLanguage queryLanguage, 
            ISQLCollectionLoadProcess sqlCollectionLoadProcess,
            ITriggerManagement triggerManagement)
        {
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
            this.sqlCollectionLoadProcess = sqlCollectionLoadProcess ?? throw new ArgumentNullException(nameof(sqlCollectionLoadProcess));
            this.triggerManagement =  triggerManagement ?? throw new ArgumentNullException(nameof(triggerManagement));
        }

        public ICollectionLoadResponse Load(ICollectionLoadStatementRequest loadRequest)
        {
            IParameterizedCommand selectStatement = null;
            List<string> augmentedRequestedColumns = new List<string>();

            if (loadRequest.ColumnExpressionByColumnName.Count > 0)
            {
                triggerManagement.AugmentLoadRequestWithAdditionalColumns(
                loadRequest, out augmentedRequestedColumns, out Dictionary<string, string> augmentedColumnExpressionByColumnName);

                selectStatement = queryLanguage.SQLStatement(
                                 augmentedRequestedColumns,
                                 augmentedColumnExpressionByColumnName,
                                 loadRequest.SelectStatement);

            }
            else
            {
                triggerManagement.AugmentLoadRequestWithAdditionalColumns(
                loadRequest, out augmentedRequestedColumns, out Dictionary<string, IParameterizedCommand> augmentedColumnExpressionByColumnName);

                var missingColumnExpressions = augmentedRequestedColumns.Where(c => !augmentedColumnExpressionByColumnName.ContainsKey(c) || string.IsNullOrWhiteSpace(augmentedColumnExpressionByColumnName[c].Statement));
                Contract.Requires<ArgumentOutOfRangeException>(missingColumnExpressions.Count() == 0, string.Format("requestedColumns {0} require a column expression", string.Join(", ", missingColumnExpressions)));

                selectStatement = queryLanguage.SQLStatement(
                                augmentedRequestedColumns,
                                augmentedColumnExpressionByColumnName,
                                loadRequest.SelectStatement);
            }

            return this.sqlCollectionLoadProcess.Process(loadRequest.ColumnNameByVariableToAssign, selectStatement.Statement, selectStatement.Parameters, 0, augmentedRequestedColumns);
        }
    }
}
