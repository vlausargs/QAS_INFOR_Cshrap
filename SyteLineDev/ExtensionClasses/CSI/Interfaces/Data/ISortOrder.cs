using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    /// <summary>
    /// A sort order is an ordered list of columns, each with an ascending or descending specification
    /// </summary>
    public interface ISortOrder
    {
        IEnumerable<ISortOrderColumn> Columns { get; }
    }
}