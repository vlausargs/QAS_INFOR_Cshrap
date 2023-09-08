using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using CSI.Data.RecordSets;
using CSI.Data.CRUD.Triggers;
using System.Data;
using CSI.Data.CRUD;

namespace CSI.Data.SQL
{
    public partial class SQLQueryLanguage : IQueryLanguage
    {
        readonly IParameterProvider parameterProvider;
        readonly ISQLParameterizedCommandFactory parameterizedCommandFactory;

        public SQLQueryLanguage(IParameterProvider parameterProvider, ISQLParameterizedCommandFactory parameterizedCommandFactory)
        {
            this.parameterProvider = parameterProvider;
            this.parameterizedCommandFactory = parameterizedCommandFactory;
        }

        #region Where Clause

        public IParameterizedCommand WhereClause(string whereClauseTemplate, params object[] whereClauseParameters)
        {
            var parameterList = new List<string>();
            var whereParms = new List<IDataParameter>();

            int pindex = 0;
            foreach (var parameter in whereClauseParameters)
            {
                var parameterName = $"@p{pindex++}";
                var parameterValue = parameter is IUDDTType ? (parameter as IUDDTType).Value : parameter;
                parameterList.Add(parameterName);
                whereParms.Add(parameterProvider.CreateParameter(parameterName, parameterValue));
            }

            var whereClause = parameterizedCommandFactory.Create(string.Format(whereClauseTemplate, parameterList.ToArray()), whereParms);  //parameter list needs to be in array.
            //whereClause.Statement = string.Format(whereClauseTemplate, parameterList.ToArray()); //parameter list needs to be in array.

            return whereClause;
        }

        public IParameterizedCommand WhereClauseFromRecord(IEnumerable<string> key, IRecordInternal record)
        {
            var recordInternal = record as IRecordInternal;
            if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

            var whereClauseParts = new List<string>();
            var whereParms = new List<IDataParameter>();

            foreach (var column in key)
            {
                whereClauseParts.Add(QuoteName(column) + " = @v" + column);
                if (record is IRecordWithDeleted recordWithDeleted)
                    whereParms.Add(parameterProvider.CreateParameter("@v" + column, recordWithDeleted.GetDeletedValue<object>(column)));
                else
                    whereParms.Add(parameterProvider.CreateParameter("@v" + column, record.GetValue(column)));
            }

            var whereClause = parameterizedCommandFactory.Create(string.Join(" AND ", whereClauseParts), whereParms);
            //whereClause.Statement = string.Join(" AND ", whereClauseParts);
            return whereClause;
        }

        public IParameterizedCommand WhereClauseFromKeyValues(
            IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            var whereClauseParts = new List<string>();
            var whereParms = new List<IDataParameter>();

            foreach (var pair in valuesByKeyColumn)
            {
                var column = pair.Key;
                var varName = pair.Key.Replace(".", "_"); //special case for keys or columnname using alias.
                whereClauseParts.Add(QuoteName(column) + " = @v" + varName);
                var variable = pair.Value;
                var variableValue = variable is IUDDTType ? (variable as IUDDTType).Value : variable;
                whereParms.Add(parameterProvider.CreateParameter("@v" + varName, variableValue)); //changed variable to variableValue.
            }

            var whereClause = parameterizedCommandFactory.Create(string.Join(" AND ", whereClauseParts), whereParms);
            //whereClause.Statement = string.Join(" AND ", whereClauseParts);
            return whereClause;
        }

        /// <summary>
        /// Create a where clause that selects records that come AFTER the bookmarked record
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        IParameterizedCommand WhereClauseFromBookmark(IBookmark bookmark)
        {
            //The generated where clause will be true when:
            //  a record's column value is after the value of the first sort order column value in the bookmark
            //  or is equal to the first sort order column and after the second sort order column
            //  or is equal to the first two sort order columns and after the third sort order column
            //  or etc...
            var whereClauseParameters = new List<IDataParameter>();
            string whereClause = string.Empty;

            bool firstColumn = true;
            foreach (var column in bookmark.Columns)
            {
                if (!firstColumn) whereClause += " or ";
                whereClause += "(";

                bool firstPreceedingColumn = true;
                foreach (var preceedingColumn in bookmark.Columns)
                {
                    if (preceedingColumn.Name == column.Name)
                        //there are no more preceeding columns
                        break;

                    if (!firstPreceedingColumn) whereClause += " and ";

                    var preceedingParameterName = $"@_{preceedingColumn.Name.GetHashCode().ToString("X")}";
                    var preceedingColumnDefaultNullValue = string.Empty;
                    
                    if (preceedingColumn.DefaultValue is null)
                        preceedingColumnDefaultNullValue = "''";
                    else
                    {
                        if (Convert.ToString(preceedingColumn.DefaultValue) == "")
                            preceedingColumnDefaultNullValue = "''";
                        else
                            preceedingColumnDefaultNullValue = Convert.ToString(preceedingColumn.DefaultValue);
                    }

                    whereClause += string.Format($"ISNULL({preceedingColumn.Name}, {preceedingColumnDefaultNullValue}) = ISNULL({preceedingParameterName}, {preceedingColumnDefaultNullValue})");
                    if (!whereClauseParameters.Any(p => p.ParameterName == preceedingParameterName))
                        //add it if it's not already on the list
                        whereClauseParameters.Add(parameterProvider.CreateParameter(preceedingParameterName, preceedingColumn.Value));

                    firstPreceedingColumn = false;
                }

                if (!firstPreceedingColumn) whereClause += " and ";

                var parameterName = $"@_{column.Name.GetHashCode().ToString("X")}";
                var columnDefaultNullValue = string.Empty;

                if (column.DefaultValue is null)
                    columnDefaultNullValue = "''";
                else
                {
                    if (Convert.ToString(column.DefaultValue) == "")
                        columnDefaultNullValue = "''";
                    else
                        columnDefaultNullValue = Convert.ToString(column.DefaultValue);
                }

                whereClause += string.Format($"ISNULL({column.Name}, {columnDefaultNullValue}) {(column.Direction == SortOrderDirection.Ascending ? ">" : " < ")} ISNULL({parameterName}, {columnDefaultNullValue})");
                if (!whereClauseParameters.Any(p => p.ParameterName == parameterName))
                    //add it if it's not already on the list
                    whereClauseParameters.Add(parameterProvider.CreateParameter(parameterName, column.Value));

                whereClause += ")";
                firstColumn = false;
            }

            return parameterizedCommandFactory.Create(whereClause, whereClauseParameters);
        }

        #endregion

        #region Update Statement

        public IParameterizedCommand UpdateStatementFromValues(
            string tableName,
            IReadOnlyDictionary<string, object> valuesByColumnToAssign,
            IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            //create the set list
            var setParts = new List<string>();
            var setParms = new List<IDataParameter>();

            foreach (var pair in valuesByColumnToAssign)
            {
                var column = pair.Key;
                var variable = pair.Value;
                var variableValue = variable is IUDDTType ? (variable as IUDDTType).Value : variable;

                setParts.Add(QuoteName(column) + "= @u" + column);
                setParms.Add(parameterProvider.CreateParameter("@u" + column, variableValue));
            }

            var setClause = parameterizedCommandFactory.Create(string.Join(", ", setParts), setParms);
            //setClause.Statement = string.Join(", ", setParts);

            //create the where clause
            var whereClause = WhereClauseFromKeyValues(valuesByKeyColumn);

            //create the final statement
            string updStmt = $"UPDATE {QuoteName(tableName)} SET {setClause.Statement} WHERE {whereClause.Statement}";
            var updateStatement = parameterizedCommandFactory.Create(updStmt);
            //updateStatement.Statement = $"UPDATE {QuoteName(tableName)} SET {setClause.Statement} WHERE {whereClause.Statement}";

            return parameterizedCommandFactory.Create(updateStatement.Statement, updateStatement.Parameters.Union(setClause.Parameters).Union(whereClause.Parameters));
        }

        public IParameterizedCommand UpdateStatementFromRecord(
            string tableName,
            IEnumerable<string> uniqueIndexColumns,
            IEnumerable<string> columnsToUpdate,
            IRecordInternal record)
        {
            //create the set list
            var setParts = new List<string>();
            var parameterCounter = 0;
            var setParms = new List<IDataParameter>();

            foreach (var column in columnsToUpdate)
            {
                //$"@u{parameterCounter}"
                setParts.Add(QuoteName(column) + $"= @u{parameterCounter}");
                setParms.Add(parameterProvider.CreateParameter($"@u{parameterCounter}", record.GetValue(column)));
                parameterCounter++;
            }

            var setClause = parameterizedCommandFactory.Create(string.Join(", ", setParts), setParms);
            //setClause.Statement = string.Join(", ", setParts);

            //create the where clause
            var whereClause = WhereClauseFromRecord(uniqueIndexColumns, record);

            //create the final statement
            string updStmt = $"UPDATE {QuoteName(tableName)} SET {setClause.Statement}";
            updStmt += string.IsNullOrEmpty(whereClause.Statement) ? "" : $" WHERE {whereClause.Statement}";
            var updateStatement = parameterizedCommandFactory.Create(updStmt);
            //updateStatement.Statement = $"UPDATE {QuoteName(tableName)} SET {setClause.Statement}";
            //updateStatement.Statement += string.IsNullOrEmpty(whereClause.Statement) ? "" : $" WHERE {whereClause.Statement}";

            return parameterizedCommandFactory.Create(updateStatement.Statement, updateStatement.Parameters.Union(setClause.Parameters).Union(whereClause.Parameters));
        }

        public IParameterizedCommand UpdateStatementWithFromWhereClause(string tableName,
            int maxRows,
            IReadOnlyDictionary<string, IParameterizedCommand> expressionByColumnToAssign,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause)
        {
            //create the set list
            var setParts = new List<string>();
            var setParms = new List<IDataParameter>();
            string topClause = (maxRows > 0) ? $"TOP ({maxRows}) " : "";

            if (expressionByColumnToAssign != null)
            {
                foreach (var pair in expressionByColumnToAssign)
                {
                    var column = pair.Key;
                    var expression = pair.Value;
                    var columnValue = expression.Statement;

                    int i = 0;
                    foreach (var expParm in expression.Parameters)
                    {
                        setParms.Add(parameterProvider.CreateParameter($"@u{column}{i}", expParm.Value));
                        columnValue = columnValue.Replace(expParm.ParameterName, $"@u{column}{i++}");
                    }
                    setParts.Add($"{QuoteName(column)} = {columnValue}");
                }
            }

            var setClause = parameterizedCommandFactory.Create(string.Join(", ", setParts), setParms);

            //create the where clause
            var wherePart = string.IsNullOrWhiteSpace(whereClause.Statement) ? "" : $" WHERE {whereClause.Statement}";

            var fromPart = string.IsNullOrWhiteSpace(fromClause.Statement) ? "" : $" FROM {EvaluateFromClause(fromClause)}";

            //create the final statement
            string updStmt = $"UPDATE {topClause}{QuoteName(tableName)} SET {setClause.Statement}{fromPart}{wherePart}";
            var updateStatement = parameterizedCommandFactory.Create(updStmt);

            return parameterizedCommandFactory.Create(updateStatement.Statement, updateStatement.Parameters
                .Union(setClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(fromClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(whereClause?.Parameters ?? Enumerable.Empty<IDataParameter>()));
        }

        #endregion

        #region Delete Statement

        public IParameterizedCommand DeleteStatementFromKeyValues(
            string tableName,
            IReadOnlyDictionary<string, object> variablesByKeyColumn)
        {
            //create the where clause
            var whereClause = WhereClauseFromKeyValues(variablesByKeyColumn);

            //create the final 
            string delStmt = $"DELETE FROM {QuoteName(tableName)} WHERE {whereClause.Statement}";
            var deleteStatement = parameterizedCommandFactory.Create(delStmt);
            //deleteStatement.Statement = $"DELETE FROM {QuoteName(tableName)} WHERE {whereClause.Statement}";

            return parameterizedCommandFactory.Create(deleteStatement.Statement, deleteStatement.Parameters.Union(whereClause.Parameters));
        }

        public IParameterizedCommand DeleteStatementFromRecord(
            string tableName,
            IEnumerable<string> uniqueIndexColumns,
            IRecordInternal record)
        {
            //create the where clause
            var whereClause = WhereClauseFromRecord(uniqueIndexColumns, record);

            //create the final statement
            string delStmt = $"DELETE FROM {QuoteName(tableName)} WHERE {whereClause.Statement}";
            var deleteStatement = parameterizedCommandFactory.Create(delStmt);
            //deleteStatement.Statement = $"DELETE FROM {QuoteName(tableName)} WHERE {whereClause.Statement}";

            return parameterizedCommandFactory.Create(deleteStatement.Statement, deleteStatement.Parameters.Union(whereClause.Parameters));
        }

        public IParameterizedCommand DeleteStatementWithFromWhereClause(string tableName, int maxRows, IParameterizedCommand fromClause, IParameterizedCommand whereClause)
        {
            string topClause = (maxRows > 0) ? $"TOP ({maxRows}) " : "";

            // create the from clause
            var fromPart = string.IsNullOrWhiteSpace(fromClause.Statement) ? "" : $" FROM {EvaluateFromClause(fromClause)}";

            //create the where clause
            var wherePart = string.IsNullOrWhiteSpace(whereClause.Statement) ? "" : $" WHERE {whereClause.Statement}";

            //create the final statement
            string deleteStmt = $"DELETE {topClause}FROM {QuoteName(tableName)}{fromPart}{wherePart}";
            var deleteStatement = parameterizedCommandFactory.Create(deleteStmt);

            return parameterizedCommandFactory.Create(deleteStatement.Statement,
                deleteStatement.Parameters
                .Union(fromClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(whereClause?.Parameters ?? Enumerable.Empty<IDataParameter>()));
        }

        #endregion

        #region Insert Statement

        public IParameterizedCommand InsertStatementFromValues(
            string tableName,
            IReadOnlyDictionary<string, object> valuesByColumnToAssign)
        {
            //create the set list
            var setParts = new List<string>();
            var getParts = new List<string>();
            var setParms = new List<IDataParameter>();

            foreach (var pair in valuesByColumnToAssign)
            {
                var column = pair.Key;
                var variable = pair.Value;

                setParts.Add(QuoteName(column));
                getParts.Add("@u" + column);
                object variableValue = variable is IUDDTType ? (variable as IUDDTType).Value : variable;
                setParms.Add(parameterProvider.CreateParameter("@u" + column, variableValue));
            }

            var setClause = parameterizedCommandFactory.Create(string.Join(", ", setParts), setParms);
            var getClause = parameterizedCommandFactory.Create(string.Join(", ", getParts));
            //setClause.Statement = string.Join(", ", setParts);
            //getClause.Statement = string.Join(", ", getParts);

            //create the final statement
            string insertStmnt = $"INSERT INTO {QuoteName(tableName)} ( {setClause.Statement} ) VALUES ( {getClause.Statement} )";
            var insertStatement = parameterizedCommandFactory.Create(insertStmnt);
            //insertStatement.Statement = $"INSERT INTO {QuoteName(tableName)} ( {setClause.Statement} ) VALUES ( {getClause.Statement} )";

            return parameterizedCommandFactory.Create(insertStatement.Statement, insertStatement.Parameters.Union(setClause.Parameters).Union(getClause.Parameters));
        }

        public IParameterizedCommand InsertStatementFromRecord(
            string tableName,
            IEnumerable<string> columnsToInsert,
            IRecordInternal record)
        {
            //create the set list
            var setParts = new List<string>();
            var getParts = new List<string>();
            var setParms = new List<IDataParameter>();
            var parameterCounter = 0;
            foreach (var column in columnsToInsert)
            {
                setParts.Add(QuoteName(column));
                getParts.Add($"@u{parameterCounter}");
                setParms.Add(parameterProvider.CreateParameter($"@u{parameterCounter}", record.GetValue(column)));
                parameterCounter++;
            }

            var setClause = parameterizedCommandFactory.Create(string.Join(", ", setParts), setParms);
            var getClause = parameterizedCommandFactory.Create(string.Join(", ", getParts));
            //setClause.Statement = string.Join(", ", setParts);
            //getClause.Statement = string.Join(", ", getParts);

            //create the final statement
            string statement = $"INSERT INTO {QuoteName(tableName)} ( {setClause.Statement} ) VALUES ( {getClause.Statement} )";
            var insertStatement = parameterizedCommandFactory.Create(statement);

            return parameterizedCommandFactory.Create(insertStatement.Statement, insertStatement.Parameters.Union(setClause.Parameters).Union(getClause.Parameters));
        }


        public IParameterizedCommand InsertStatementFromExpressionValues(string targetTableName,
                                                                         List<string> targetColumns,
                                                                         IReadOnlyDictionary<string, IParameterizedCommand> valuesByExpressionToAssign,
                                                                         int maximumRows,
                                                                         IParameterizedCommand fromClause,
                                                                         IParameterizedCommand whereClause,
                                                                         IParameterizedCommand orderByClause,
                                                                         bool distinct)
        {
            string topClause = (maximumRows > 0) ? $"TOP ({maximumRows}) " : "";

            string insertColumns = string.Join(", ", targetColumns.Select(c => QuoteName(c)));

            var selectClause = CreateSelectClauseParameterized(targetColumns, valuesByExpressionToAssign);

            //create the from clause
            var fromPart = string.IsNullOrWhiteSpace(fromClause?.Statement) ? "" : $" FROM {EvaluateFromClause(fromClause)}";

            //create the where clause
            var wherePart = string.IsNullOrWhiteSpace(whereClause?.Statement) ? "" : $" WHERE {whereClause.Statement}";

            //create the orderby clause
            var orderByPart = string.IsNullOrWhiteSpace(orderByClause?.Statement) ? "" : $" ORDER BY {EvaluateOrderByClause(orderByClause)}";

            //create the final statement
            string insStmt = $"INSERT INTO {QuoteName(targetTableName)} ({insertColumns}) SELECT {(distinct ? "DISTINCT " : "")}{topClause}{selectClause.Statement}{fromPart}{wherePart}{orderByPart}";
            var insertStatement = parameterizedCommandFactory.Create(insStmt);

            return parameterizedCommandFactory.Create(insertStatement.Statement, insertStatement.Parameters
                .Union(selectClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(fromClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(whereClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(orderByClause?.Parameters ?? Enumerable.Empty<IDataParameter>()));
        }

        #endregion

        #region Select Statement
        public IParameterizedCommand SelectStatement(
            IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, string> columnExpressionsByColumnName,
            string tableName,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int maxRows,
            LockingType lockingType)
        {
            var tempFromClause = CloneParameterizedCommand(fromClause);
            var tempWhereClause = CloneParameterizedCommand(whereClause);
            var tempOrderByClause = CloneParameterizedCommand(orderByClause);

            //create the select statement
            string selectStatement = "SELECT ";
            Dictionary<string, string> newKeyValue = new Dictionary<string, string>();
            if (maxRows != 0) selectStatement += $"TOP {maxRows} ";

            string selectList = string.Join(", ", requestedColumns.Select(c => string.Format("{0} {1}", columnExpressionsByColumnName[c], QuoteName(c))));
            selectStatement += selectList;

            selectStatement += $" FROM {tableName}";

            string evaluatedFromClause = "";
            if (fromClause != null && !string.IsNullOrWhiteSpace(fromClause.Statement))
                evaluatedFromClause = EvaluateFromClause(tempFromClause);
            evaluatedFromClause = AddLockToTargetTable(lockingType, evaluatedFromClause);
            selectStatement += $" {evaluatedFromClause}";

            if (whereClause != null && !string.IsNullOrWhiteSpace(whereClause.Statement))
                selectStatement += $" WHERE {tempWhereClause.Statement}";

            if (orderByClause != null && !string.IsNullOrWhiteSpace(orderByClause.Statement))
                selectStatement += $" ORDER BY {EvaluateOrderByClause(tempOrderByClause)}";

            var command = parameterizedCommandFactory.Create(selectStatement);

            return parameterizedCommandFactory.Create(command.Statement, command.Parameters
                .Union(tempFromClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(tempWhereClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(tempOrderByClause?.Parameters ?? Enumerable.Empty<IDataParameter>()));
        }

        /// <summary>
        /// Build the Select Statement with parameterized select elements
        /// </summary>
        /// <param name="requestedColumns">Column Names</param>
        /// <param name="columnExpressionsByColumnName">Parameterized Select Elements</param>
        /// <param name="fromClause">Parameterized From Clause</param>
        /// <param name="tableName">Table Name</param>
        /// <param name="lockingType">Locking Type</param>
        /// <param name="maxRows">Number of records</param>
        /// <param name="orderByClause">Parameterized Order By Clause</param>
        /// <param name="whereClause">Parameterized Where Clause</param>
        public IParameterizedCommand SelectStatement(
            IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, IParameterizedCommand> columnExpressionsByColumnName,
            string tableName,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int maxRows,
            LockingType lockingType)
        {
            var tempFromClause = CloneParameterizedCommand(fromClause);
            var tempWhereClause = CloneParameterizedCommand(whereClause);
            var tempOrderByClause = CloneParameterizedCommand(orderByClause);

            var selectClause = CreateSelectClauseParameterized(requestedColumns, columnExpressionsByColumnName);

            //create the from clause
            string evaluatedFromClause = "";
            if (fromClause != null && !string.IsNullOrWhiteSpace(fromClause?.Statement))
                evaluatedFromClause = EvaluateFromClause(tempFromClause);
            evaluatedFromClause = AddLockToTargetTable(lockingType, evaluatedFromClause);
            var fromClauseStatement = $"{evaluatedFromClause}";

            //create the where clause
            var whereClauseStatement = string.Empty;
            if (whereClause != null && !string.IsNullOrWhiteSpace(whereClause?.Statement))
                whereClauseStatement = $"WHERE {tempWhereClause.Statement}";

            //create the orderby clause
            var orderByClauseStatement = string.Empty;
            if (orderByClause != null && !string.IsNullOrWhiteSpace(orderByClause.Statement))
                orderByClauseStatement = $"ORDER BY {EvaluateOrderByClause(tempOrderByClause)}";

            //create the final statement
            string topStatement = string.Empty;
            if (maxRows != 0) topStatement = $"TOP {maxRows}";

            string selectStatement = string.Format("SELECT {0} {1} FROM {2} {3} {4} {5}",
                topStatement,
                selectClause.Statement,
                tableName,
                fromClauseStatement,
                whereClauseStatement,
                orderByClauseStatement);

            var command = parameterizedCommandFactory.Create(selectStatement);

            return parameterizedCommandFactory.Create(command.Statement, command.Parameters
                .Union(selectClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(tempFromClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(tempWhereClause?.Parameters ?? Enumerable.Empty<IDataParameter>())
                .Union(tempOrderByClause?.Parameters ?? Enumerable.Empty<IDataParameter>()));
        }


        #endregion

        #region SQL Statement

        public IParameterizedCommand SQLStatement(IEnumerable<string> requestedColumns,
           IReadOnlyDictionary<string, string> columnExpressionsByColumnName,
           IParameterizedCommand selectStatement)
        {
            Dictionary<string, string> newKeyValue = new Dictionary<string, string>();
            string statement = string.Empty;

            if (selectStatement != null && !string.IsNullOrWhiteSpace(selectStatement.Statement))
                statement += $" {selectStatement.Statement}";

            string cols = string.Join(", ", requestedColumns.Select(c => string.Format("{0} {1}",
                columnExpressionsByColumnName[c].Substring(0, 1) == "@" ? QuoteName(columnExpressionsByColumnName[c]) : columnExpressionsByColumnName[c], QuoteName(c))));

            statement = statement.Replace("@selectList", cols);

            var command = parameterizedCommandFactory.Create(statement, selectStatement?.Parameters);
            //command.Statement = statement;
            //if (selectStatement != null) command.Parameters.AddRange(selectStatement.Parameters);
            return command;
        }

        /// <summary>
        /// Build the SQL Statement with parameterized select elements
        /// </summary>
        /// <param name="requestedColumns">Column Names</param>
        /// <param name="columnExpressionsByColumnName">Parameterized Select Elements</param>
        /// <param name="selectStatement">Select Statement</param>
        public IParameterizedCommand SQLStatement(IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, IParameterizedCommand> columnExpressionsByColumnName,
            IParameterizedCommand selectStatement)
        {
            string statement = string.Empty;

            if (selectStatement != null && !string.IsNullOrWhiteSpace(selectStatement.Statement))
                statement += $" {selectStatement.Statement}";


            //create the select statement
            IParameterizedCommand selectClause = CreateSelectClauseParameterized(requestedColumns, columnExpressionsByColumnName);

            statement = statement.Replace("@selectList", selectClause.Statement);

            return parameterizedCommandFactory.Create(statement, selectStatement?.Parameters
                .Union(selectClause?.Parameters ?? Enumerable.Empty<IDataParameter>()));
        }

        #endregion

        public IParameterizedCommand OrderByClause(ISortOrder so)
        {
            return parameterizedCommandFactory.Create(string.Join(", ", so.Columns.Select(c => $"{c.Name} {(c.Direction == SortOrderDirection.Descending ? " DESC" : string.Empty)}")));
        }

        /// <summary>
        /// Take an existing where clause and append the bookmark criteria to it
        /// </summary>
        public IParameterizedCommand AppendBookmark(IParameterizedCommand whereClause, IBookmark bookmark)
        {
            var bookmarkClause = WhereClauseFromBookmark(bookmark);

            //make sure there are no conflicting parameter names
            (whereClause, bookmarkClause) = Deconflict(whereClause, bookmarkClause);

            //join the two expressions
            string whereStatement = string.IsNullOrEmpty(whereClause.Statement) ? "1=1" : whereClause.Statement;
            var newClause = $"({whereStatement}) and ({bookmarkClause.Statement})";

            return parameterizedCommandFactory.Create(newClause, whereClause.Parameters.Union(bookmarkClause.Parameters));
        }

        (IParameterizedCommand, IParameterizedCommand) Deconflict(IParameterizedCommand a, IParameterizedCommand b)
        {
            //if there are parameters with the same names, change the name of the second one
            //it doesn't matter if the values are the same, we still change the names if there's a conflict

            var newClause = b.Statement;
            var newParms = new List<IDataParameter>();

            foreach (var parm in b.Parameters)
            {
                if (a.Parameters.Any(p => p.ParameterName == parm.ParameterName))
                {
                    //we have a conflict -> change the name by sticking a number on the end of it
                    //we do a very unimaginative search of the namespace
                    int suffix = 0;
                    var newParmName = parm.ParameterName + (suffix++).ToString();
                    while (a.Parameters.Any(p => p.ParameterName == newParmName))
                        newParmName = parm.ParameterName + (suffix++).ToString();

                    newClause = newClause.Replace(parm.ParameterName, newParmName);
                    newParms.Add(parameterProvider.CreateParameter(newParmName, parm.Value));
                    continue;
                }

                //no conflict, just add the parameter as is
                newParms.Add(parm);
            }

            return (a, parameterizedCommandFactory.Create(newClause, newParms));
        }       

        public string AddLockToTargetTable(LockingType lockingType, string fromClause)
        {
            string locking = GetLockingType(lockingType);
            if (string.IsNullOrEmpty(locking)) return fromClause;
            if (string.IsNullOrWhiteSpace(fromClause)) return $" WITH ({locking})";
            IList<string> splitedFromClause = fromClause.Split(' ');
            StringBuilder fromClauseWithTableHints = new StringBuilder();
            bool tableHintsLocaltionIsFound = false;
            bool keywordAsisFound = false;
            bool switchedToOtherTables = false;
            for (int i = 0; i < splitedFromClause.Count; i++)
            {
                string current = splitedFromClause[i];
                string formattedCurrent = i == 0 ? current : " " + current; //add whitespace back.
                #region the same lock already exist in fromClause against primary table. Ignore the adding action.
                if (switchedToOtherTables == false && current.ToUpper().Contains(locking.ToUpper()))
                    return fromClause;
                #endregion
                if (tableHintsLocaltionIsFound)
                {
                    fromClauseWithTableHints.Append(formattedCurrent);
                    continue; //add all rest string into the fromClauseWithTableHints
                }
                if (current != "")
                {
                    if (formattedCurrent.Contains(","))
                    {
                        formattedCurrent = formattedCurrent.Insert(formattedCurrent.IndexOf(","), $" WITH ({locking})");
                        tableHintsLocaltionIsFound = true;
                    }
                    #region meet join associated keywords
                    else if ((string.Compare(current, "INNER", StringComparison.InvariantCultureIgnoreCase) == 0)
                        || (string.Compare(current, "LEFT", StringComparison.InvariantCultureIgnoreCase) == 0)
                        || (string.Compare(current, "FULL", StringComparison.InvariantCultureIgnoreCase) == 0)
                        || (string.Compare(current, "RIGHT", StringComparison.InvariantCultureIgnoreCase) == 0)
                        || (string.Compare(current, "CROSS", StringComparison.InvariantCultureIgnoreCase) == 0)
                        || (string.Compare(current, "OUTER", StringComparison.InvariantCultureIgnoreCase) == 0)
                        || (string.Compare(current, "JOIN", StringComparison.InvariantCultureIgnoreCase) == 0)
                        || (current == ",")
                            )
                    {
                        tableHintsLocaltionIsFound = true;
                        switchedToOtherTables = true;
                        fromClauseWithTableHints.Append($" WITH ({locking}) ");
                    }
                    #endregion meet join associated keywords
                    #region "Using AS keyworkd"
                    else if (string.Compare(current, "AS", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        //if keyword as is find, the next string is the alis
                        keywordAsisFound = true;
                    }
                    else if (keywordAsisFound)
                    {
                        tableHintsLocaltionIsFound = true;
                        formattedCurrent += $" WITH ({locking}) ";
                    }
                    #endregion "Using AS keyworkd"                    
                }
                fromClauseWithTableHints.Append(formattedCurrent);
            }
            //at the end, if still not find appropriate location, add the table hint at the last place.
            if (!tableHintsLocaltionIsFound)
                fromClauseWithTableHints.Append($" WITH ({locking})");
            return fromClauseWithTableHints.ToString();
        }

        public string GetLockingType(LockingType lockingType)
        {
            if (lockingType == LockingType.None) return string.Empty;
            return Enum.GetName(typeof(LockingType), lockingType).ToUpper();
        }


        #region Private Methods


        private string EvaluateOrderByClause(IParameterizedCommand orderByClause)
        {
            string formattedOrderByClauseStatement = orderByClause.Statement;

            for (int i = 0; i < orderByClause.Parameters.Count(); i++)
            {
                var parm = orderByClause.Parameters.ElementAt(i);

                if (parm.ParameterName.Contains("p"))
                {
                    parm.ParameterName = $"@o{i}";
                    formattedOrderByClauseStatement = formattedOrderByClauseStatement.Replace($"@p{i}", $"@o{i}");
                }
            }

            return formattedOrderByClauseStatement;
        }

        string QuoteName(string name)
        {
            //https://stackoverflow.com/questions/2547514/correct-escaping-of-delimited-identifers-in-sql-server-without-using-quotename
            const int sysnameLength = 128;

            name = name ?? String.Empty;
            if (name.Length > sysnameLength)
                throw new ArgumentException($"name may not be longer than {sysnameLength} characters");

            return String.Format("[{0}]", name.Replace("]", "]]"));
        }

        private IParameterizedCommand CreateSelectClauseParameterized(
            IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, IParameterizedCommand> columnExpressionsByColumnName)
        {
            //create the set list
            var selectParts = new List<string>();
            var selectParms = new List<IDataParameter>();

            foreach (string colName in requestedColumns)
            {
                var kvp = columnExpressionsByColumnName.Where(x => x.Key.Equals(colName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (!kvp.Equals(default(KeyValuePair<string, IParameterizedCommand>)))
                {
                    var column = kvp.Key;
                    var expression = kvp.Value;
                    var columnValue = expression.Statement;

                    int i = 0;
                    foreach (var expParm in expression.Parameters)
                    {
                        selectParms.Add(parameterProvider.CreateParameter($"@u{column}{i}", expParm.Value));
                        columnValue = columnValue.Replace(expParm.ParameterName, $"@u{column}{i++}");
                    }
                    selectParts.Add($"{columnValue} {QuoteName(column)}");

                }
            }

            var selectClause = parameterizedCommandFactory.Create(string.Join(", ", selectParts), selectParms);
            return selectClause;
        }

        private IParameterizedCommand CloneParameterizedCommand(IParameterizedCommand parameterizedCommandToClone)
        {
            if (parameterizedCommandToClone == null) return null;

            List<IDataParameter> parameterList = new List<IDataParameter>();
            foreach (IDataParameter parameter in parameterizedCommandToClone.Parameters)
            {
                parameterList.Add(parameterProvider.CreateParameter(parameter.ParameterName, parameter.Value));
            }
            var clonedParameterizedCommand = parameterizedCommandFactory.Create(parameterizedCommandToClone.Statement, parameterList);
            return clonedParameterizedCommand;
        }

        private string EvaluateFromClause(IParameterizedCommand fromClause)
        {
            string formattedFromClauseStatement = fromClause.Statement;

            for (int i = 0; i < fromClause.Parameters.Count(); i++)
            {
                var parm = fromClause.Parameters.ElementAt(i);

                if (parm.ParameterName.Contains("p"))
                {
                    parm.ParameterName = $"@f{i}";
                    formattedFromClauseStatement = formattedFromClauseStatement.Replace($"@p{i}", $"@f{i}");
                }
            }

            return formattedFromClauseStatement;
        }

        #endregion
    }
}