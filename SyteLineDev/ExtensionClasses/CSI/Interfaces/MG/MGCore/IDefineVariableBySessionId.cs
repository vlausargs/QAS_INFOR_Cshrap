//PROJECT NAME: MG.MGCore
//CLASS NAME: IDefineVariableBySessionId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IDefineVariableBySessionId
    {
        (int? ReturnCode, string VariableValue,
        string Infobar) DefineVariableBySessionIdSp(Guid? SessionID,
        string VariableName,
        string VariableValue,
        string Infobar);
    }
}

