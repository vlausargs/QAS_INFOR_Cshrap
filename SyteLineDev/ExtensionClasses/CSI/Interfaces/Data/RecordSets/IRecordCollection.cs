using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.RecordSets
{
    public interface IRecordCollection : IEnumerable<IRecord>, IEnumerable
    {
        IEnumerable<string> Columns { get; }
        int Count { get; }
        IRecord this[int recordPostion] { get; }
        bool HasMGItemIDs { get; }
    }
}
