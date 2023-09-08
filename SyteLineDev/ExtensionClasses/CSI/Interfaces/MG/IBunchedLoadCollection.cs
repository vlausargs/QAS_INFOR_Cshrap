using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IBunchedLoadCollection
    {
        LoadType LoadType { get; }
        int RecordCap { get; }
        void StartBunching();
        void EndBunching();
    }
}
