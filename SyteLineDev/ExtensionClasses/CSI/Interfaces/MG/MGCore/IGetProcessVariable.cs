//PROJECT NAME: MG.MGCore
//CLASS NAME: IGetProcessVariable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IGetProcessVariable
    {
        (int? ReturnCode, string VariableValue,
        string Infobar) GetProcessVariableSp(string VariableName,
        string DefaultValue,
        int? DeleteVariable,
        string VariableValue,
        string Infobar);
    }
}

