using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionNonTriggerUpdate : ISQLCollectionNonTriggerUpdate
    {

        IQueryLanguage queryLanguage;
        ICommandProvider commandProvider;

        public SQLCollectionNonTriggerUpdate(IQueryLanguage queryLanguage, ICommandProvider commandProvider)
        {
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
            this.commandProvider = commandProvider ?? throw new ArgumentNullException(nameof(commandProvider));
        }

        public void UpdateWithoutTrigger(ICollectionNonTriggerUpdateRequest updateRequest)
        {
            if (updateRequest.ExpressionByColumnToAssign == null)
                throw new Exception("ValuesByColumnToAssign must be specified for this method.");

            if (updateRequest.ExpressionByColumnToAssign.Count == 0)
            {
                //nothing to udpate
                return;
            }
            SQLUpdateWithVariablesNonKey(updateRequest);
        }

        void SQLUpdateWithVariablesNonKey(ICollectionNonTriggerUpdateRequest updateRequest)
        {
            var updateStatement = queryLanguage.UpdateStatementWithFromWhereClause(updateRequest.TableName,
                                                                                   updateRequest.MaximumRows,
                                                                                   updateRequest.ExpressionByColumnToAssign,
                                                                                   updateRequest.FromClause,
                                                                                   updateRequest.WhereClause);

            using (IDbCommand cmd = commandProvider.CreateCommand())
            {
                cmd.CommandText = updateStatement.Statement;
                cmd.CommandType = CommandType.Text;
                foreach (var parameter in updateStatement.Parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
        }

    }
}
