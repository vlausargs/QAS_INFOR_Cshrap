using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.RecordSets
{
    public interface IRecordInternal : IRecord
    {
        string MGItemID { get; }
    }
}
