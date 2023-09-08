//PROJECT NAME: Logistics
//CLASS NAME: IDefineVariable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IDefineVariable
    {
        (int? ReturnCode, string Infobar) DefineVariableSp(string VariableName,
        string VariableValue,
        string Infobar);
    }
}

