using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionNonTriggerInsert : ISQLCollectionNonTriggerInsert
    {

        IQueryLanguage queryLanguage;
        ICommandProvider commandProvider;

        public SQLCollectionNonTriggerInsert(IQueryLanguage queryLanguage, ICommandProvider commandProvider)
        {
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
            this.commandProvider = commandProvider ?? throw new ArgumentNullException(nameof(commandProvider));
        }

        public void InsertWithoutTrigger(ICollectionNonTriggerInsertRequest insertRequest)
        {
            if (insertRequest.ValuesByExpressionToAssign == null)
                throw new Exception("ValuesByExpressionToAssign must be specified for this method.");

            if (insertRequest.ValuesByExpressionToAssign.Count == 0)
            {
                //nothing to udpate
                return;
            }
            SQLInsertWithoutTrigger(insertRequest);
        }

        void SQLInsertWithoutTrigger(ICollectionNonTriggerInsertRequest insertRequest)
        {
            var insertStatement = queryLanguage.InsertStatementFromExpressionValues(insertRequest.TargetTableName, 
                                                                                        insertRequest.TargetColumns, 
                                                                                        insertRequest.ValuesByExpressionToAssign, 
                                                                                        insertRequest.MaximumRows,
                                                                                        insertRequest.FromClause,
                                                                                        insertRequest.WhereClause,
                                                                                        insertRequest.OrderByClause,
                                                                                        insertRequest.Distinct);

            using (IDbCommand cmd = commandProvider.CreateCommand())
            {
                cmd.CommandText = insertStatement.Statement;
                cmd.CommandType = CommandType.Text;
                foreach (var parameter in insertStatement.Parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
        }

    }
}
