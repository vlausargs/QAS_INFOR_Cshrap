//PROJECT NAME: MG.MGCore
//CLASS NAME: IDefineProcessVariable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IDefineProcessVariable
    {
        (int? ReturnCode, string Infobar) DefineProcessVariableSp(string VariableName,
        string VariableValue,
        string Infobar);
    }
}

