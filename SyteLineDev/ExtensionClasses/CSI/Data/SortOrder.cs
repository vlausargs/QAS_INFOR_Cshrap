using System.Collections.Generic;

namespace CSI.Data
{
    public class SortOrder : ISortOrder
    {
        readonly Dictionary<string, SortOrderDirection> so;
        readonly Dictionary<string, object> defaultValue;
        public SortOrder(Dictionary<string, SortOrderDirection> so)
        {
            this.so = so;
            this.defaultValue = null;
        }

        public SortOrder(Dictionary<string, SortOrderDirection> so, Dictionary<string, object> defaultValue)
        {
            this.so = so;
            this.defaultValue = defaultValue;
        }

        public IEnumerable<ISortOrderColumn> Columns
        {
            get
            {
                if (defaultValue == null)
                {
                    foreach (string column in so.Keys)
                        yield return new SortOrderColumn(column, so[column]);
                }
                else
                {
                    foreach (string column in so.Keys)
                        yield return new SortOrderColumn(column, so[column],
                            defaultValue.ContainsKey(column) ? defaultValue[column] : null);
                }
            }
        }
    }
}