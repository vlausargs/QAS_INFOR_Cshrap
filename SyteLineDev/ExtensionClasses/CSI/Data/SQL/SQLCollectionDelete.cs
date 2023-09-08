using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using CSI.Data.RecordSets;
using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;

namespace CSI.Data.SQL
{
    public class SQLCollectionDelete : ICollectionDelete
    {
        readonly ICommandProvider cp;
        readonly IQueryLanguage queryLanguage;
        readonly IAppDbSchema appDbSchema;
        readonly ITriggerManagement triggerManagement;

        public SQLCollectionDelete(ICommandProvider cp, IQueryLanguage queryLanguage, IAppDbSchema appDbSchema, ITriggerManagement triggerManagement)
        {
            this.cp = cp ?? throw new ArgumentNullException(nameof(cp));
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
            this.appDbSchema = appDbSchema ?? throw new ArgumentNullException(nameof(appDbSchema));
            this.triggerManagement = triggerManagement ?? throw new ArgumentNullException(nameof(triggerManagement));
        }

        public void Delete(ICollectionDeleteRequest deleteRequest)
        {
            if (deleteRequest.Items != null)
            {
                if (deleteRequest.Items.Count == 0)
                {
                    //nothing to delete
                    return;
                }
                DeleteFromTable(deleteRequest);
                return;
            }

            if(deleteRequest.ValuesByKeyColumn != null)
            {
                if (deleteRequest.ValuesByKeyColumn.Count == 0)
                {
                    //nothing to delete
                    return;
                }
                DeleteFromValues(deleteRequest);
                return;
            }

            IRecordCollection deleted = triggerManagement.CreateDeletedFromDeleteRequest(deleteRequest);
            triggerManagement.ExecuteTriggerAfterDelete(deleteRequest.TableName, deleted);
        }

        void DeleteFromTable(ICollectionDeleteRequest deleteRequest)
        {
            var primaryKey = appDbSchema.GetPrimaryKeyColumns(deleteRequest.TableName);
            if (primaryKey.Any(k => !deleteRequest.Items.Columns.Contains(k)))
                //the primary key wasn't passed in
                throw new Exception($"Required primary key values for {deleteRequest.TableName} are {string.Join(", ", primaryKey)}");

            // When no PK, use all columns as key
            if(primaryKey.Count() == 0)
            {
                primaryKey = deleteRequest.Items.Columns;
            }

            foreach (var record in deleteRequest.Items)
            {
                var recordInternal = record as IRecordInternal;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

                var deleteStatement = queryLanguage.DeleteStatementFromRecord(deleteRequest.TableName, primaryKey, recordInternal);

                using (IDbCommand cmd = cp.CreateCommand())
                {
                    cmd.CommandText = deleteStatement.Statement;
                    foreach (var parameter in deleteStatement.Parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void DeleteFromValues(ICollectionDeleteRequest deleteRequest)
        {
            var primaryKey = appDbSchema.GetPrimaryKeyColumns(deleteRequest.TableName);
            if (primaryKey.Any(k => !deleteRequest.ValuesByKeyColumn.ContainsKey(k)))
                //the primary key wasn't passed in
                throw new Exception($"Required primary key values for {deleteRequest.TableName} are {string.Join(", ", primaryKey)}");

            var deleteStatement = queryLanguage.DeleteStatementFromKeyValues(deleteRequest.TableName, deleteRequest.ValuesByKeyColumn);

            using (IDbCommand cmd = cp.CreateCommand())
            {
                cmd.CommandText = deleteStatement.Statement;
                foreach (var parameter in deleteStatement.Parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }
}
