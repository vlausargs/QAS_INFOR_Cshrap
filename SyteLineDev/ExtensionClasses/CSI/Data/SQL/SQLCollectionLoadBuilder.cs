using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionLoadBuilder : ICollectionLoadBuilder
    {
        readonly ISQLCollectionLoadBuilderProcess sQLCollectionLoadBuildProcess;

        public SQLCollectionLoadBuilder(ISQLCollectionLoadBuilderProcess sQLCollectionLoadBuildProcess)
        {
            this.sQLCollectionLoadBuildProcess = sQLCollectionLoadBuildProcess;
        }

        public ICollectionLoadResponse Load(ICollectionLoadBuilderRequest loadBuildRequest)
        {
            if (loadBuildRequest.ColumnExpressionByColumnName.Count > 0)
            {
                return this.sQLCollectionLoadBuildProcess.Process(
                    loadBuildRequest.ColumnNameByVariableToAssign,
                    loadBuildRequest.RequestedColumns,
                    loadBuildRequest.ColumnExpressionByColumnName);
            }
            else
            {
                return this.sQLCollectionLoadBuildProcess.Process(
                    loadBuildRequest.ColumnNameByVariableToAssign,
                    loadBuildRequest.RequestedColumns,
                    loadBuildRequest.ColumnParametizedByColumnName);
            }
        }
    }
}
