using CSI.Data.RecordSets;
using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD.Triggers
{
    public interface ITriggerManagement
    {
        void SnapshotDataBeforeMGDelete(string baseTable, ITriggerState triggerState, IEnumerable<string> deletedItemIDs);

        void SnapshotDataBeforeMGUpdate(string baseTable, ITriggerState triggerState, IEnumerable<string> modifiedItemIDs);

        IRecordCollection CreateInsertedFromInsertRequest(ICollectionInsertRequest insertRequest);

        IRecordCollectionWithDeleted CreateInsertedFromUpdateRequest(ICollectionUpdateRequest updateRequest);

        IRecordCollection CreateDeletedFromDeleteRequest(ICollectionDeleteRequest deleteRequest);

        void ExecuteTriggerAfterInsert(string tableName, IRecordCollection inserted);

        void ExecuteTriggerAfterUpdate(string tableName, IRecordCollectionWithDeleted inserted);

        void ExecuteTriggerAfterDelete(string tableName, IRecordCollection deleted);

        IEnumerable<string> GetColumnsRequiredForUpdateTrigger(string tableName);

        IEnumerable<string> GetColumnsRequiredForDeleteTrigger(string tableName);

        void AugmentLoadRequestWithAdditionalColumns(
            ICollectionLoadRequest loadRequest,
            out List<string> augmentedRequesteColumns,
            out Dictionary<string, string> augmentedColumnExpressionByColumnName);

        void AugmentLoadRequestWithAdditionalColumns(
          ICollectionLoadRequest loadRequest,
          out List<string> augmentedRequestedColumns,
          out Dictionary<string, IParameterizedCommand> augmentedColumnExpressionByColumnName);

        void AugmentLoadRequestWithAdditionalColumns(
            ICollectionLoadStatementRequest loadRequest,
            out List<string> augmentedRequestedColumns,
            out Dictionary<string, string> augmentedColumnExpressionByColumnName);

        void AugmentLoadRequestWithAdditionalColumns(
            ICollectionLoadStatementRequest loadRequest,
            out List<string> augmentedRequestedColumns,
            out Dictionary<string, IParameterizedCommand> augmentedColumnExpressionByColumnName);
    }
}
