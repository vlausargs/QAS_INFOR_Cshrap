using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionLoadNonArbitrary : ICollectionLoad
    {
        readonly IQueryLanguage queryLanguage;
        readonly ITriggerManagement triggerManagement;
        readonly ISQLCollectionLoadProcess sqlCollectionLoadProcess;

        public SQLCollectionLoadNonArbitrary(
            IQueryLanguage queryLanguage,
            ITriggerManagement triggerManagement,
            ISQLCollectionLoadProcess sqlCollectionLoadProcess)
        {
            this.queryLanguage = queryLanguage;
            this.triggerManagement = triggerManagement;
            this.sqlCollectionLoadProcess = sqlCollectionLoadProcess;
        }

        public ICollectionLoadResponse Load(ICollectionLoadRequest loadRequest)
        {
            IParameterizedCommand selectStatement = null;
            List<string> augmentedRequestedColumns = new List<string>();

            if (loadRequest.ColumnExpressionByColumnName.Count > 0)
            {
                triggerManagement.AugmentLoadRequestWithAdditionalColumns(
                loadRequest, out augmentedRequestedColumns, out Dictionary<string, string> augmentedColumnExpressionByColumnName);

                var missingColumnExpressions = augmentedRequestedColumns.Where(c => !augmentedColumnExpressionByColumnName.ContainsKey(c) || string.IsNullOrWhiteSpace(augmentedColumnExpressionByColumnName[c]));
                Contract.Requires<ArgumentOutOfRangeException>(missingColumnExpressions.Count() == 0, string.Format("requestedColumns {0} require a column expression", string.Join(", ", missingColumnExpressions)));

                selectStatement = queryLanguage.SelectStatement(
                     augmentedRequestedColumns,
                     augmentedColumnExpressionByColumnName,
                     loadRequest.TableName,
                     loadRequest.FromClause,
                     loadRequest.WhereClause,
                     loadRequest.OrderByClause,
                     loadRequest.MaximumRows,
                     loadRequest.LockingType);
            }
            else
            {
                triggerManagement.AugmentLoadRequestWithAdditionalColumns(
                loadRequest, out augmentedRequestedColumns, out Dictionary<string, IParameterizedCommand> augmentedColumnExpressionByColumnName);

                var missingColumnExpressions = augmentedRequestedColumns.Where(c => !augmentedColumnExpressionByColumnName.ContainsKey(c) || string.IsNullOrWhiteSpace(augmentedColumnExpressionByColumnName[c].Statement));
                Contract.Requires<ArgumentOutOfRangeException>(missingColumnExpressions.Count() == 0, string.Format("requestedColumns {0} require a column expression", string.Join(", ", missingColumnExpressions)));

                selectStatement = queryLanguage.SelectStatement(
                   augmentedRequestedColumns,
                   augmentedColumnExpressionByColumnName,
                   loadRequest.TableName,
                   loadRequest.FromClause,
                   loadRequest.WhereClause,
                   loadRequest.OrderByClause,
                   loadRequest.MaximumRows,
                   loadRequest.LockingType);
            }

            return this.sqlCollectionLoadProcess.Process(loadRequest.ColumnNameByVariableToAssign, selectStatement.Statement, selectStatement.Parameters, loadRequest.MaximumRows, augmentedRequestedColumns);
        }
    }
}
