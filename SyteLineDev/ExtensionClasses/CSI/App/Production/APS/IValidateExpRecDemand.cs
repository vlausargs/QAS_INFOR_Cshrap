//PROJECT NAME: Production
//CLASS NAME: IValidateExpRecDemand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface IValidateExpRecDemand
    {
        (int? ReturnCode, string Infobar) ValidateExpRecDemandSp(string DemandType, string DemandNum, string Infobar);
    }
}

