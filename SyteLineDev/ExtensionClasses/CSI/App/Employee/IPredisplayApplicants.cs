//PROJECT NAME: Employee
//CLASS NAME: IPredisplayApplicants.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
    public interface IPredisplayApplicants
    {
        (int? ReturnCode,
        int? PCheckSsnEnabled) PredisplayApplicantsSp(
            int? PCheckSsnEnabled);
    }
}

