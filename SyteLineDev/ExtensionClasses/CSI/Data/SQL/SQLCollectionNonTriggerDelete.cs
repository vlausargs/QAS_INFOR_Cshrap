using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionNonTriggerDelete : ISQLCollectionNonTriggerDelete
    {

        IQueryLanguage queryLanguage;
        ICommandProvider commandProvider;

        public SQLCollectionNonTriggerDelete(IQueryLanguage queryLanguage, ICommandProvider commandProvider)
        {
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
            this.commandProvider = commandProvider ?? throw new ArgumentNullException(nameof(commandProvider));
        }

        public void DeleteWithoutTrigger(ICollectionNonTriggerDeleteRequest deleteRequest)
        {
            var deleteStatement = queryLanguage.DeleteStatementWithFromWhereClause(deleteRequest.TableName, deleteRequest.MaximumRows, deleteRequest.FromClause, deleteRequest.WhereClause);

            using (IDbCommand cmd = commandProvider.CreateCommand())
            {
                cmd.CommandText = deleteStatement.Statement;
                cmd.CommandType = CommandType.Text;
                foreach (var parameter in deleteStatement.Parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }
}
