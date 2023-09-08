//PROJECT NAME: MG.MGCore
//CLASS NAME: IUndefineVariableBySessionId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IUndefineVariableBySessionId
    {
        (int? ReturnCode, string Infobar) UndefineVariableBySessionIdSp(Guid? SessionID,
        string VariableName,
        string Infobar);
    }
}

