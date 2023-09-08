//PROJECT NAME: Employee
//CLASS NAME: IAlertPORequisition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
    public interface IAlertPORequisition
    {
        (int? ReturnCode,
        string Inforbar) AlertPORequisitionSp(
            string RequestType,
            string EmpNum,
            string SupEmpNum,
            string RequesterName,
            string ApproverName,
            string ReqNum,
            int? ReqLine,
            string ReqCode,
            string ReqCodeDescription,
            string Item,
            string ItemDescription,
            string Inforbar);
    }
}

