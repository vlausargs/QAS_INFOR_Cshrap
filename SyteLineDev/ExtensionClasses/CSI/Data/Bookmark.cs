using CSI.Data.Cache;
using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;

namespace CSI.Data
{
    public class Bookmark : IBookmark, ICachable
    {
        readonly IRecordReadOnly record;
        readonly ISortOrder SortOrder;
        readonly Dictionary<string, object> columnDefaultValue;

        public Bookmark(IRecordReadOnly record, ISortOrder so, Dictionary<string, object> columnDefaultValue = null)
        {
            this.record = record;
            this.SortOrder = so;
            this.columnDefaultValue = columnDefaultValue;
        }

        public IEnumerable<IBookmarkColumn> Columns
        {
            get
            {
                foreach (var column in SortOrder.Columns)
                {
                    if (!record.Contains(column.Name))
                        throw new Exception($"Value not available for column {column.Name}");

                    if (this.columnDefaultValue is null)
                        yield return new BookmarkColumn(column.Name, column.Direction, record.GetValue<object>(column.Name));
                    else
                        yield return new BookmarkColumn(
                            column.Name, 
                            column.Direction, 
                            record.GetValue<object>(column.Name), 
                            columnDefaultValue.ContainsKey(column.Name) ? columnDefaultValue[column.Name] : null);
                }
            }
        }
    }
}