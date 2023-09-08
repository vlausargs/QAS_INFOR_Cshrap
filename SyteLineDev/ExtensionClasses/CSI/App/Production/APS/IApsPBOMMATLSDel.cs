//PROJECT NAME: Production
//CLASS NAME: IApsPBOMMATLSDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface IApsPBOMMATLSDel
    {
        int? ApsPBOMMATLSDelSp(
            int? AltNo,
            Guid? RowPointer);
    }
}

