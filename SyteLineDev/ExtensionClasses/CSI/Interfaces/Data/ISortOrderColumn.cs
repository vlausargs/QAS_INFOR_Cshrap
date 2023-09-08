using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface ISortOrderColumn
    {
        string Name { get; }
        SortOrderDirection Direction { get; }
        object DefaultWhenNull { get; }
    }
}