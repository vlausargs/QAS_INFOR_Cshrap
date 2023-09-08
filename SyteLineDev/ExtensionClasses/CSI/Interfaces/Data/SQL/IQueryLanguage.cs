using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface IQueryLanguage
    {
        IParameterizedCommand WhereClause(string whereClauseTemplate, params object[] whereClauseParameters);

        IParameterizedCommand WhereClauseFromRecord(IEnumerable<string> key, IRecordInternal record);

        IParameterizedCommand WhereClauseFromKeyValues(IReadOnlyDictionary<string, object> VariablesByKeyColumn);

        IParameterizedCommand UpdateStatementFromValues(
            string tableName,
            IReadOnlyDictionary<string, object> valuesByColumnToAssign,
            IReadOnlyDictionary<string, object> valuesByKeyColumn);

        IParameterizedCommand UpdateStatementFromRecord(
            string tableName,
            IEnumerable<string> uniqueIndexColumns,
            IEnumerable<string> columnsToUpdate,
            IRecordInternal record);

        IParameterizedCommand DeleteStatementFromKeyValues(
            string tableName,
            IReadOnlyDictionary<string, object> variablesByKeyColumn);

        IParameterizedCommand DeleteStatementFromRecord(
            string tableName,
            IEnumerable<string> uniqueIndexColumns,
            IRecordInternal record);
        IParameterizedCommand InsertStatementFromValues(
            string tableName,
            IReadOnlyDictionary<string, object> valuesByColumnToAssign);

        IParameterizedCommand InsertStatementFromRecord(
            string tableName,
            IEnumerable<string> columnsToInsert,
            IRecordInternal record);

        IParameterizedCommand SelectStatement(
            IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, string> columnExpressionsByColumnName,
            string tableName,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int maxRows,
            LockingType lockingType);

        IParameterizedCommand SelectStatement(
         IEnumerable<string> requestedColumns,
         IReadOnlyDictionary<string, IParameterizedCommand> columnExpressionsByColumnName,
         string tableName,
         IParameterizedCommand fromClause,
         IParameterizedCommand whereClause,
         IParameterizedCommand orderByClause,
         int maxRows,
         LockingType lockingType);

        IParameterizedCommand SQLStatement(
            IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, string> columnExpressionsByColumnName,
            IParameterizedCommand selectStatement);

        IParameterizedCommand SQLStatement(IEnumerable<string> requestedColumns,
           IReadOnlyDictionary<string, IParameterizedCommand> columnExpressionsByColumnName,
           IParameterizedCommand selectStatement);

        IParameterizedCommand AppendBookmark(IParameterizedCommand whereClause, IBookmark bookmark);

        IParameterizedCommand OrderByClause(ISortOrder so);

        IParameterizedCommand UpdateStatementWithFromWhereClause(
            string tableName,
            int maxRows,
            IReadOnlyDictionary<string, IParameterizedCommand> expressionByColumnToAssign,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause);

        IParameterizedCommand DeleteStatementWithFromWhereClause(string tableName,
            int maxRows,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause);

        IParameterizedCommand InsertStatementFromExpressionValues(string targetTableName,
                                                          List<string> targetColumns,
                                                          IReadOnlyDictionary<string, IParameterizedCommand> valuesByExpressionToAssign,
                                                          int maximumRows,
                                                          IParameterizedCommand fromClause,
                                                          IParameterizedCommand whereClause,
                                                          IParameterizedCommand orderByClause,
                                                          bool distinct);

    }
}
