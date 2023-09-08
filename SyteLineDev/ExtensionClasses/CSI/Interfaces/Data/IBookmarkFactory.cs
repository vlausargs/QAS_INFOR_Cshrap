using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IBookmarkFactory
    {
        IBookmark Create(IRecordReadOnly record, ISortOrder sortOrder);
    }
}
