//PROJECT NAME: Logistics.Customer
//CLASS NAME: IProcessShipmentProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IProcessShipmentProcess
    {
        (int? ReturnCode, string Infobar) ProcessShipmentProcessSp(Guid? TCoNumRowPointer,
        Guid? TCustAddrRowPointer,
        int? CreditHoldChanged,
        Guid? TrnRowPointer,
        string Infobar);
    }
}

