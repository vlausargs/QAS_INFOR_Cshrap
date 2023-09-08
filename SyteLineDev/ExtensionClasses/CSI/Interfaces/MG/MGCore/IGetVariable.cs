//PROJECT NAME: MG.MGCore
//CLASS NAME: IGetVariable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IGetVariable
    {
        (int? ReturnCode, string VariableValue,
        string Infobar) GetVariableSp(string VariableName,
        string DefaultValue,
        int? DeleteVariable,
        string VariableValue,
        string Infobar);
    }
}

