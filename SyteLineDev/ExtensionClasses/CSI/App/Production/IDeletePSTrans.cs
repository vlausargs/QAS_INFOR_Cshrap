//PROJECT NAME: Production
//CLASS NAME: IDeletePSTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
    public interface IDeletePSTrans
    {
        (int? ReturnCode,
        string Infobar) DeletePSTransSp(
            Guid? SessionID,
            string Infobar);
    }
}

