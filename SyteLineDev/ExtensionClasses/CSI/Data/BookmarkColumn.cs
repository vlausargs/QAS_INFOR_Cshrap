using System;

namespace CSI.Data
{
    public class BookmarkColumn : IBookmarkColumn
    {
        public string Name { get; }
        public SortOrderDirection Direction { get; }
        public object Value { get; }
        public object DefaultValue { get; }

        public BookmarkColumn(string name, SortOrderDirection direction, object value)
        {
            this.Name = name;
            this.Direction = direction;
            this.Value = value;
        }

        public BookmarkColumn(string name, SortOrderDirection direction, object value, object defaultValue)
        {
            this.Name = name;
            this.Direction = direction;
            this.Value = value;
            this.DefaultValue = defaultValue;
        }
    }
}