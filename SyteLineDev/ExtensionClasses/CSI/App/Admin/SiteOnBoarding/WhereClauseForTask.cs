using System;
using System.Collections.Generic;
using System.Linq;
using CSI.Data;
using CSI.Data.RecordSets;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IWhereClauseForTask
    {
        IBookmark GetBookmark(IRecordReadOnly bookmarkRow, List<string> primaryKeys);
        string WhereClauseFromBookmark(IBookmark bookmark);
    }

    public class WhereClauseForTask : IWhereClauseForTask
    {
        private readonly ISortOrderFactory _sortOrderFactory;
        private readonly IBookmarkFactory _bookmarkFactory;

        public WhereClauseForTask(ISortOrderFactory sortOrderFactory, IBookmarkFactory bookmarkFactory)
        {
            _sortOrderFactory = sortOrderFactory;
            _bookmarkFactory = bookmarkFactory;
        }

        public IBookmark GetBookmark(IRecordReadOnly bookmarkRow, List<string> primaryKeys)
        {
            var sortOrderDictionary = primaryKeys.Select((s, i) => new {s, i}).ToDictionary(x => x.s, x => SortOrderDirection.Ascending);
            var sortOrder = _sortOrderFactory.Create(sortOrderDictionary);

            return _bookmarkFactory.Create(bookmarkRow, sortOrder);
        }

        public string WhereClauseFromBookmark(IBookmark bookmark)
        {
            var whereClause = "(";

            var firstColumn = true;
            foreach (var column in bookmark.Columns)
            {
                if (!firstColumn) whereClause += " or ";
                whereClause += "(";

                var firstProceedingColumn = true;
                foreach (var proceedingColumn in bookmark.Columns)
                {
                    if (proceedingColumn.Name == column.Name)
                        break;

                    if (!firstProceedingColumn) whereClause += " and ";

                    var proceedingColumnValue = proceedingColumn.Value;
                    string proceedingColumnDefaultNullValue;

                    if (proceedingColumn.DefaultValue is null)
                        proceedingColumnDefaultNullValue = "''";
                    else
                    {
                        if (Convert.ToString(proceedingColumn.DefaultValue) == "")
                            proceedingColumnDefaultNullValue = "''";
                        else
                            proceedingColumnDefaultNullValue = Convert.ToString(proceedingColumn.DefaultValue);
                    }

                    whereClause +=
                        string.Format($"ISNULL({proceedingColumn.Name}, {proceedingColumnDefaultNullValue}) = '{proceedingColumnValue}'");

                    firstProceedingColumn = false;
                }

                if (!firstProceedingColumn) whereClause += " and ";

                var columnValue = column.Value;
                string columnDefaultNullValue;

                if (column.DefaultValue is null)
                    columnDefaultNullValue = "''";
                else
                {
                    if (Convert.ToString(column.DefaultValue) == "")
                        columnDefaultNullValue = "''";
                    else
                        columnDefaultNullValue = Convert.ToString(column.DefaultValue);
                }

                whereClause +=
                    string.Format(
                        $"ISNULL({column.Name}, {columnDefaultNullValue}) {(column.Direction == SortOrderDirection.Ascending ? ">" : " < ")} '{columnValue}'");
                whereClause += ")";
                firstColumn = false;
            }

            return whereClause + ")";
        }
    }
}