//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetIPparms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
    public interface IRSQC_GetIPparms
    {
        (int? ReturnCode,
        int? NeedsQC) RSQC_GetIPparmsSp(
            int? NeedsQC);
    }
}

