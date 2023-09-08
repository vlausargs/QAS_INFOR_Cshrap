//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSDistDefs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSDistDefs
    {
            (int? ReturnCode,
            int? AmortizeContracts,
            int? TotalPeriods,
            string Infobar) 
        SSSFSDistDefsSp(
            int? AmortizeContracts,
            int? TotalPeriods,
            string Infobar);
    }
}