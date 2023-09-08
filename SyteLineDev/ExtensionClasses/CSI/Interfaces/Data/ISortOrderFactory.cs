using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface ISortOrderFactory
    {
        ISortOrder Create(Dictionary<string, SortOrderDirection> order);
        ISortOrder Create(Dictionary<string, SortOrderDirection> order, Dictionary<string, object> defalutValue);
    }
}
