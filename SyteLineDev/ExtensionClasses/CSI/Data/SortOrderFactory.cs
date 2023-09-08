using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public class SortOrderFactory : ISortOrderFactory
    {
        public ISortOrder Create(Dictionary<string, SortOrderDirection> order)
        {
            return new SortOrder(order);
        }

        public ISortOrder Create(Dictionary<string, SortOrderDirection> order, Dictionary<string, object> defalutValue)
        {
            return new SortOrder(order, defalutValue);
        }
    }
}
