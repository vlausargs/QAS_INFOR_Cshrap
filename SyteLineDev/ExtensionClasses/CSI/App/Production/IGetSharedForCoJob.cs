//PROJECT NAME: Production
//CLASS NAME: IGetSharedForCoJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
    public interface IGetSharedForCoJob
    {
            (int? ReturnCode,
            int? Shared,
            string WC,
            int? IsCojob) 
        GetSharedForCoJobSp(
            string Job,
            int? OperNum,
            int? Suffix,
            int? Shared,
            string WC,
            int? IsCojob);
    }
}

