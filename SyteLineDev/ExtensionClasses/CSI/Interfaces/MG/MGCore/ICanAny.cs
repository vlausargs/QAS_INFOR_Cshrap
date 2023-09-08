//PROJECT NAME: MG.MGCore
//CLASS NAME: ICanAny.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ICanAny
    {
        (int? ReturnCode, int? Privilege) CanAnySp(string Type,
        string FormName,
        int? Privilege);

        int? CanAnyFn(string Type,
        string FormName);
    }
}

