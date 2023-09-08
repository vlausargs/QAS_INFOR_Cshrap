using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IBookmarkColumn
    {
        string Name { get; }
        SortOrderDirection Direction { get; }
        object Value { get; }
        object DefaultValue { get; }
    }
}