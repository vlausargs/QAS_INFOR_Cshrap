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
    public class SQLCollectionInsert : ICollectionInsert
    {
        readonly ICommandProvider cp;
        readonly ISQLBulkCopyFactory bulkCopyFactory;
        readonly IQueryLanguage queryLanguage;
        readonly ITriggerManagement triggerManagement;
        readonly IRecordCollectionToDataTable recordCollectionToDataTable;
        public SQLCollectionInsert(ICommandProvider cp, ISQLBulkCopyFactory bulkCopyFactory, IQueryLanguage queryLanguage, ITriggerManagement triggerManagement, IRecordCollectionToDataTable recordCollectionToDataTable)
        {
            this.cp = cp ?? throw new ArgumentNullException(nameof(cp));
            this.bulkCopyFactory = bulkCopyFactory ?? throw new ArgumentNullException(nameof(bulkCopyFactory));
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
            this.triggerManagement = triggerManagement ?? throw new ArgumentNullException(nameof(triggerManagement));
            this.recordCollectionToDataTable = recordCollectionToDataTable;
        }

        const int BulkTriggerThreshhold = 2; //records
        const int BulkCopyTimeout = 1600; //seconds

        public void Insert(ICollectionInsertRequest insertRequest)
        {

            if (insertRequest.ValuesByColumnToAssign != null)
            {
                if (insertRequest.ValuesByColumnToAssign.Count == 0)
                {
                    //nothing to insert
                    return;
                }
                SQLInsertFromValues(insertRequest);
                return;
            }

            if (insertRequest.Items != null)
            {
                if (insertRequest.Items.Count == 0)
                {
                    //nothing to insert
                    return;
                }
                SQLInsertFromTable(insertRequest);
                return;
            }

            IRecordCollection inserted = triggerManagement.CreateInsertedFromInsertRequest(insertRequest);
            triggerManagement.ExecuteTriggerAfterInsert(insertRequest.TableName, inserted);
        }

        void SQLInsertFromValues(ICollectionInsertRequest insertRequest)
        {
            var insertStatement = queryLanguage.InsertStatementFromValues(insertRequest.TableName, insertRequest.ValuesByColumnToAssign);

            using (IDbCommand cmd = cp.CreateCommand())
            {
                cmd.CommandText = insertStatement.Statement;
                foreach (var parameter in insertStatement.Parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
        }

        void SQLInsertFromTable(ICollectionInsertRequest insertRequest)
        {
            var recordCount = insertRequest.Items.Count;

            if (recordCount < 1)
                //nothing to do
                return;

            if (recordCount >= BulkTriggerThreshhold)
            {
                BulkInsert(insertRequest);
                return;
            }

            foreach (var record in insertRequest.Items)
            {
                var recordInternal = record as IRecordInternal;
                var recordDeleted = record as IRecordWithDeleted;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");
                if (recordDeleted == null) throw new Exception("Internal Error: IRecordWithDeleted not implemented");

                var insertStatement = queryLanguage.InsertStatementFromRecord(insertRequest.TableName, insertRequest.Items.Columns, recordInternal);

                using (IDbCommand cmd = cp.CreateCommand())
                {
                    cmd.CommandText = insertStatement.Statement;
                    foreach (var parameter in insertStatement.Parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        void BulkInsert(ICollectionInsertRequest insertRequest)
        {
            DataTable data = recordCollectionToDataTable.ToDataTable(insertRequest.Items);

            using (var bulkCopy = bulkCopyFactory.Create(cp))
            {
                bulkCopy.DestinationTableName = insertRequest.TableName;
                bulkCopy.BulkCopyTimeout = BulkCopyTimeout;
                bulkCopy.SetColumnMapping(insertRequest.Items.Columns);
                bulkCopy.WriteToServer(data);                
            }
        }
    }
}
