//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GetGoBDMediaData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.Germany
{
    public interface IRpt_GetGoBDMediaData
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GetGoBDMediaDataSp(
            Guid? ProcessId);
    }




}

