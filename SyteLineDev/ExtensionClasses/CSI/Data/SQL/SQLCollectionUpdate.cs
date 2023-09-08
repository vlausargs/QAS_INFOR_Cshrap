using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.RecordSets;

namespace CSI.Data.SQL
{
    public class SQLCollectionUpdate : ICollectionUpdate
    {
        readonly ICommandProvider cp;
        readonly IQueryLanguage queryLanguage;
        readonly IAppDbSchema appDbSchema;
        readonly ITriggerManagement triggerManagement;

        public SQLCollectionUpdate(ICommandProvider cp, IQueryLanguage queryLanguage, IAppDbSchema appDbSchema, ITriggerManagement triggerManagement)
        {
            this.cp = cp ?? throw new ArgumentNullException(nameof(cp)); ;
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
            this.appDbSchema = appDbSchema ?? throw new ArgumentNullException(nameof(appDbSchema));
            this.triggerManagement = triggerManagement ?? throw new ArgumentNullException(nameof(triggerManagement));
        }

        public void Update(ICollectionUpdateRequest updateRequest)
        {
            if (updateRequest.ValuesByColumnToAssign != null)
            {
                if (updateRequest.ValuesByColumnToAssign.Count == 0)
                {
                    //nothing to udpate
                    return;
                }
                SQLUpdateWithVariables(updateRequest);
                return;
            }

            if (updateRequest.Items != null)
            {
                if (updateRequest.Items.Count == 0)
                {
                    //nothing to udpate
                    return;
                }
                SQLUpdateFromTable(updateRequest);
                return;
            }

            IRecordCollectionWithDeleted inserted = triggerManagement.CreateInsertedFromUpdateRequest(updateRequest);
            triggerManagement.ExecuteTriggerAfterUpdate(updateRequest.TableName, inserted);
        }

        void SQLUpdateWithVariables(ICollectionUpdateRequest updateRequest)
        {
            var primaryKey = appDbSchema.GetPrimaryKeyColumns(updateRequest.TableName);
            if (primaryKey.Any(k => !updateRequest.ValuesByKeyColumn.ContainsKey(k)))
                //the primary key wasn't passed in
                throw new Exception($"Required primary key values for {updateRequest.TableName} are {string.Join(", ", primaryKey)}");

            var updateStatement = queryLanguage.UpdateStatementFromValues(updateRequest.TableName, updateRequest.ValuesByColumnToAssign, updateRequest.ValuesByKeyColumn);

            using (IDbCommand cmd = cp.CreateCommand())
            {
                cmd.CommandText = updateStatement.Statement;
                foreach (var parameter in updateStatement.Parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
        }

        void SQLUpdateFromTable(ICollectionUpdateRequest updateRequest)
        {
            var primaryKey = appDbSchema.GetPrimaryKeyColumns(updateRequest.TableName);
            if (primaryKey.Any(k => !updateRequest.Items.Columns.Contains(k)))
                //the primary key wasn't passed in
                throw new Exception($"Required primary key values for {updateRequest.TableName} are {string.Join(", ", primaryKey)}");

            foreach (var record in updateRequest.Items)
            {
                var recordInternal = record as IRecordInternal;
                var recordDeleted = record as IRecordWithDeleted;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");
                if (recordDeleted == null) throw new Exception("Internal Error: IRecordWithDeleted not implemented");

                var updateStatement = queryLanguage.UpdateStatementFromRecord(updateRequest.TableName, primaryKey, recordDeleted.ModifiedColumns, recordInternal);

                using (IDbCommand cmd = cp.CreateCommand())
                {
                    cmd.CommandText = updateStatement.Statement;
                    foreach (var parameter in updateStatement.Parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //we can't use this since it would bypass middle tier trigger logic
        //void SQLUpdateWithExpressions(IUpdateCollectionRequest updateRequest)
        //{
        //    using (IDbCommand cmd = cp.CreateCommand())
        //    {
        //        var whereClause = updateRequest.whereClause;

        //        var pairs = updateRequest.UpdateExpressionsByColumnToAssign.ToList();
        //        string assignmentList = string.Join(", ", pairs.Select(p => string.Format("{0} = {1}", p.Key, p.Value)));
        //        string updateStatement = string.Format("UPDATE {0} SET {1} WHERE {2}", updateRequest.TableName, assignmentList, whereClause);

        //        cmd.CommandText = updateStatement;
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
