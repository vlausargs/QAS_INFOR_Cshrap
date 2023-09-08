using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.RecordSets;

namespace CSI.Data
{
    public class BookmarkFactory : IBookmarkFactory
    {
        public IBookmark Create(IRecordReadOnly record, ISortOrder sortOrder)
        {
            var defaultValue = new Dictionary<string, object>();
            foreach(ISortOrderColumn sortOrderColumn in sortOrder.Columns)
            {
                if(sortOrderColumn.DefaultWhenNull != null)
                {
                    Type dataType = sortOrderColumn.DefaultWhenNull.GetType();
                    if (dataType == typeof(Guid) || dataType == typeof(string) || dataType == typeof(DateTime))
                        defaultValue.Add(sortOrderColumn.Name, $"'{sortOrderColumn.DefaultWhenNull}'");
                    else
                        defaultValue.Add(sortOrderColumn.Name, sortOrderColumn.DefaultWhenNull);
                }
            }

            return new Bookmark(record, sortOrder, defaultValue.Count == 0 ? null : defaultValue);
        }
    }
}
