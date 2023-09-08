//PROJECT NAME: MG.MGCore
//CLASS NAME: IUndefineVariable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IUndefineVariable
    {
        (int? ReturnCode, string Infobar) UndefineVariableSp(string VariableName,
        string Infobar);
    }
}

