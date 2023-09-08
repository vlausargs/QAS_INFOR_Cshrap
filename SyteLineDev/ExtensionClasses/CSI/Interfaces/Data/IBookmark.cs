using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    /// <summary>
    /// A bookmark is the sort order of a record collection plus the values of the columns in the sort order
    /// It is assumed that the columns in the sort order will uniquely identify the entry in the collection
    /// </summary>
    public interface IBookmark
    {
        IEnumerable<IBookmarkColumn> Columns { get; }
    }
}