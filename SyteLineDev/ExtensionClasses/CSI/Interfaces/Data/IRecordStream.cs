using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface IRecordStream : IDisposable
    {
        IRecordReadOnly Current { get; }
        bool Read();
        bool EOF { get; }
    }
}