using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSI.Data.RecordSets;
using CSI.Data.CRUD;
using CSI.Data.SQL;

namespace CSI.Data.CRUD.Triggers
{
    /// <summary>
    /// Triggers and fields needed for trigger execution must be registered here
    /// </summary>
    public class TriggerManagement : ITriggerManagement
    {
        readonly IAppDbSchema appDbSchema;
        readonly ISQLParameterizedCommandFactory parameterizedCommandFactory;

        public TriggerManagement(IAppDbSchema appDbSchema, 
            ISQLParameterizedCommandFactory parameterizedCommandFactory)
        {
            this.appDbSchema = appDbSchema;
            this.parameterizedCommandFactory = parameterizedCommandFactory;
        }

        public void SnapshotDataBeforeMGDelete(string tableName, ITriggerState triggerState, IEnumerable<string> deletedItemIDs)
        {
            //mongoose is about to delete the records identified by the ItemIDs
            //we need to snapshot the data before the records are deleted so that they can be available for the trigger

            var columnsNeededForDeleteTrigger = GetColumnsRequiredForDeleteTrigger(tableName);
            if (columnsNeededForDeleteTrigger.Count() == 0)
                //no data is needed
                return;

            //load the records

            //save them in triggerState for later
        }

        public void SnapshotDataBeforeMGUpdate(string tableName, ITriggerState triggerState, IEnumerable<string> modifiedItemIDs)
        {
            //mongoose is about to modify the records identified by the ItemIDs
            //we need to snapshot the data before the records are modified so that they can be available for the trigger

            var columnsNeededForUpdateTrigger = GetColumnsRequiredForUpdateTrigger(tableName);

            if (columnsNeededForUpdateTrigger.Count() == 0)
                //no data is needed
                return;

            //load the records

            //save them in triggerState for later
        }

        public IRecordCollection CreateInsertedFromInsertRequest(ICollectionInsertRequest insertRequest)
        {
            return insertRequest.Items;
        }

        public IRecordCollectionWithDeleted CreateInsertedFromUpdateRequest(ICollectionUpdateRequest updateRequest)
        {
            var columnsNeededForUpdateTrigger = GetColumnsRequiredForUpdateTrigger(updateRequest.TableName);
            if (columnsNeededForUpdateTrigger.Any(c => !updateRequest.Items.Columns.Contains(c)))
            {
                var missingColumns = string.Join(", ", columnsNeededForUpdateTrigger.Where(c => !updateRequest.Items.Columns.Contains(c)));
                throw new Exception($"Internal Error: Missing columns for {updateRequest.TableName} update request: {missingColumns}");
            }

            return updateRequest.Items;
        }

        public IRecordCollection CreateDeletedFromDeleteRequest(ICollectionDeleteRequest deleteRequest)
        {
            var columnsNeededForDeleteTrigger = GetColumnsRequiredForDeleteTrigger(deleteRequest.TableName);
            if (columnsNeededForDeleteTrigger.Any(c => !deleteRequest.Items.Columns.Contains(c)))
            {
                var missingColumns = string.Join(", ", columnsNeededForDeleteTrigger.Where(c => !deleteRequest.Items.Columns.Contains(c)));
                throw new Exception($"Internal Error: Missing columns for {deleteRequest.TableName} delete request: {missingColumns}");
            }

            return deleteRequest.Items;
        }

        public void ExecuteTriggerAfterInsert(string tableName, IRecordCollection inserted)
        {
            switch (tableName)
            {
                default:
                    //there's no trigger for this table
                    break;
            }
        }

        public void ExecuteTriggerAfterUpdate(string tableName, IRecordCollectionWithDeleted inserted)
        {
            switch (tableName)
            {
                default:
                    //there's no trigger for this table
                    break;
            }
        }

        public void ExecuteTriggerAfterDelete(string tableName, IRecordCollection deleted)
        {
            switch (tableName)
            {
                default:
                    //there's no trigger for this table
                    break;
            }
        }

        public IEnumerable<string> GetColumnsRequiredForDeleteTrigger(string tableName)
        {
            switch (tableName)
            {
                default:
                    //there's no trigger for this table
                    return new List<string>();
            }
        }

        /// <summary>
        /// Additional columns needed to execute the trigger can be registered here.  
        /// Sometimes it's best to fetch them up-front by registering them here and sometimes it's best to just load them during trigger execution.
        /// Not sure if this can even be done for IDO collections.  If not, the trigger will have to load them anyways.
        /// </summary>
        public IEnumerable<string> GetColumnsRequiredForUpdateTrigger(string tableName)
        {
            switch (tableName)
            {
                default:
                    //there's no trigger for this table
                    return new List<string>();
            }
        }

        public void AugmentLoadRequestWithAdditionalColumns(
           ICollectionLoadRequest loadRequest,
           out List<string> augmentedRequestedColumns,
           out Dictionary<string, string> augmentedColumnExpressionByColumnName)
        {
            List<string> additionalColumns;
            string tableName;

            AugmentRequestedColumns(loadRequest, out augmentedRequestedColumns, out additionalColumns, out tableName);

            //add the additional column expressions
            //if these don't compile, then there are aliases or mongoose column names in play and the developer will just have to
            //  either enter everything manually in the original load request
            //  or manually handle it here (but you can only have one global SQL alias if you do something here)
            switch (tableName)
            {
                default:
                    augmentedColumnExpressionByColumnName = new Dictionary<string, string>();

                    string tableAlias = GetTableAliasByLoadRequest(tableName, $"{loadRequest.TableName} {loadRequest.FromClause.Statement}");

                    foreach (var entry in loadRequest.ColumnExpressionByColumnName)
                        //copy over the original expressions
                        augmentedColumnExpressionByColumnName.Add(entry.Key, entry.Value);

                    foreach (var c in additionalColumns)
                    {
                        if (!string.IsNullOrEmpty(tableAlias))
                        {
                            augmentedColumnExpressionByColumnName.Add(c, $"{tableAlias}.{c}");
                        }
                        else
                        {
                            //simplisticly generate new expressions
                            augmentedColumnExpressionByColumnName.Add(c, $"{tableName}.{c}");
                        }
                    }

                    break;
            }
           
        }

        public void AugmentLoadRequestWithAdditionalColumns(
          ICollectionLoadRequest loadRequest,
          out List<string> augmentedRequestedColumns,
          out Dictionary<string, IParameterizedCommand> augmentedColumnExpressionByColumnName)
        {
            List<string> additionalColumns;
            string tableName;

            AugmentRequestedColumns(loadRequest, out augmentedRequestedColumns, out additionalColumns, out tableName);

            //add the additional column expressions
            //if these don't compile, then there are aliases or mongoose column names in play and the developer will just have to
            //  either enter everything manually in the original load request
            //  or manually handle it here (but you can only have one global SQL alias if you do something here)
            switch (tableName)
            {
                default:
                    augmentedColumnExpressionByColumnName = new Dictionary<string, IParameterizedCommand>();

                    string tableAlias = GetTableAliasByLoadRequest(tableName, $"{loadRequest.TableName} {loadRequest.FromClause.Statement}");

                    foreach (var entry in loadRequest.ColumnParametizedByColumnName)
                        //copy over the original expressions
                        augmentedColumnExpressionByColumnName.Add(entry.Key, entry.Value);

                    foreach (var c in additionalColumns)
                    {
                        if (!string.IsNullOrEmpty(tableAlias))
                        {
                            augmentedColumnExpressionByColumnName.Add(c, parameterizedCommandFactory.Create($"{tableAlias}.{c}"));
                        }
                        else
                        {
                            //simplisticly generate new expressions
                            augmentedColumnExpressionByColumnName.Add(c, parameterizedCommandFactory.Create($"{tableName}.{c}"));
                        }
                    }

                    break;
            }

        }

        public void AugmentLoadRequestWithAdditionalColumns(
            ICollectionLoadStatementRequest loadRequest, 
            out List<string> augmentedRequestedColumns, 
            out Dictionary<string, string> augmentedColumnExpressionByColumnName)
        {
            var additionalColumns = new List<string>();
            var tableName = loadRequest.TargetTableName;
            if (!string.IsNullOrEmpty(tableName))
            {
                additionalColumns.AddRange(appDbSchema.GetPrimaryKeyColumns(tableName));
                additionalColumns = additionalColumns.Distinct().Where(c => !loadRequest.RequestedColumns.Contains(c)).ToList();
            }

            augmentedRequestedColumns = new List<string>(loadRequest.RequestedColumns);
            augmentedRequestedColumns.AddRange(additionalColumns);

            switch (tableName)
            {
                default:
                    augmentedColumnExpressionByColumnName = new Dictionary<string, string>();

                    foreach (var entry in loadRequest.ColumnExpressionByColumnName)
                        //copy over the original expressions
                        augmentedColumnExpressionByColumnName.Add(entry.Key, entry.Value);

                    foreach (var c in additionalColumns)
                        //simplisticly generate new expressions
                        augmentedColumnExpressionByColumnName.Add(c, $"{tableName}.{c}");


                    break;
            }
        }

        public void AugmentLoadRequestWithAdditionalColumns(
          ICollectionLoadStatementRequest loadRequest,
          out List<string> augmentedRequestedColumns,
          out Dictionary<string, IParameterizedCommand> augmentedColumnExpressionByColumnName)
        {
            var additionalColumns = new List<string>();
            var tableName = loadRequest.TargetTableName;
            if (!string.IsNullOrEmpty(tableName))
            {
                additionalColumns.AddRange(appDbSchema.GetPrimaryKeyColumns(tableName));
                additionalColumns = additionalColumns.Distinct().Where(c => !loadRequest.RequestedColumns.Contains(c)).ToList();
            }

            augmentedRequestedColumns = new List<string>(loadRequest.RequestedColumns);
            augmentedRequestedColumns.AddRange(additionalColumns);

            switch (tableName)
            {
                default:
                    augmentedColumnExpressionByColumnName = new Dictionary<string, IParameterizedCommand>();

                    foreach (var entry in loadRequest.ColumnParametizedByColumnName)
                        //copy over the original expressions
                        augmentedColumnExpressionByColumnName.Add(entry.Key, entry.Value);

                    foreach (var c in additionalColumns)
                        //simplisticly generate new expressions
                        augmentedColumnExpressionByColumnName.Add(c, parameterizedCommandFactory.Create($"{tableName}.{c}"));


                    break;
            }
        }

        private string GetTableAliasByLoadRequest(string tableName, string combinedFromClauseStatement)
        {
            var listOfReservedWords = new List<string>() { "INNER", "OUTER", "JOIN", "WITH", "ON", "AND", "LIKE" };
            string foundAlias = "";

            List<string> splitted = combinedFromClauseStatement.Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x) && !x.Equals("AS", StringComparison.InvariantCultureIgnoreCase)).ToList();

            for (int i = 0; i < splitted.Count; i++)
            {
                if (splitted[i].Equals(tableName, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (i < splitted.Count - 1 && splitted[i] != ",")
                    {
                        //Removes ',' just incase it is with the alias when splitted.
                        foundAlias = splitted[i + 1].Replace(",", "");
                        break;
                    }
                }
            }

            if (listOfReservedWords.Any(x => foundAlias.ToUpper() == x))
                foundAlias = string.Empty;

            return foundAlias;
        }

        private void AugmentRequestedColumns(ICollectionLoadRequest loadRequest, 
            out List<string> augmentedRequestedColumns, 
            out List<string> additionalColumns, 
            out string tableName)
        {
            bool theseRecordsMayGetUpdated = loadRequest.LoadForChange;
            bool theseRecordsMayGetDeleted = loadRequest.LoadForChange;

            additionalColumns = new List<string>();
            tableName = string.IsNullOrEmpty(loadRequest.TargetTableName) ? loadRequest.TableName : loadRequest.TargetTableName;
            if (theseRecordsMayGetUpdated || theseRecordsMayGetDeleted)
            {
                //add any needed primary key columns to the requested columns
                additionalColumns.AddRange(appDbSchema.GetPrimaryKeyColumns(tableName));
                // if target (for update/delete) table is different from the main table, add primary key columns as well

                if (theseRecordsMayGetUpdated)
                    //add columns needed for the update trigger
                    additionalColumns.AddRange(GetColumnsRequiredForUpdateTrigger(tableName));

                if (theseRecordsMayGetDeleted)
                    //add columns needed for the delete trigger
                    additionalColumns.AddRange(GetColumnsRequiredForDeleteTrigger(tableName));

                additionalColumns = additionalColumns.Distinct().Where(c => !loadRequest.RequestedColumns.Contains(c)).ToList();
            }
            else
            {
                //the user doesn't intend to save these records back, so there's no need to load key columns or columns needed for a trigger execution
                //if the user tries to perform an update anyways, the update routines and the triggers should throw an error mentioning the missing needed columns
            }

            //create the full augmented list
            augmentedRequestedColumns = new List<string>(loadRequest.RequestedColumns);
            augmentedRequestedColumns.AddRange(additionalColumns);
        }

    }
}
