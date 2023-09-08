//PROJECT NAME: Codes
//CLASS NAME: IGetParmCancellation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
    public interface IGetParmCancellation
    {
        (int? ReturnCode,
        int? EnableCancellation) GetParmCancellationSp(
            int? EnableCancellation);
    }
}

