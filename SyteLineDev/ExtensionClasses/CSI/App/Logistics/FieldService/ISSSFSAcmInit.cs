//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcmInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSAcmInit
    {
        (int? ReturnCode,
        string Id,
        int? TotalPeriods,
        string Infobar) SSSFSAcmInitSp(
            string Id,
            int? TotalPeriods,
            string Infobar);
    }
}

