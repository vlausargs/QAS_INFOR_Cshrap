namespace CSI.Data
{
    public class SortOrderColumn : ISortOrderColumn
    {
        public string Name { get; }
        public SortOrderDirection Direction { get; }

        public object DefaultWhenNull { get; }

        public SortOrderColumn(string name, SortOrderDirection direction)
        {
            this.Name = name;
            this.Direction = direction;
            this.DefaultWhenNull = null;
        }

        public SortOrderColumn(string name, SortOrderDirection direction, object defaultValue)
        {
            this.Name = name;
            this.Direction = direction;
            this.DefaultWhenNull = defaultValue;
        }
    }
}