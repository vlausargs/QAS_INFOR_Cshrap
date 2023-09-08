//PROJECT NAME: MG.MGCore
//CLASS NAME: ICopySessionVariables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ICopySessionVariables
    {
        int? CopySessionVariablesSp(string SessionId);
    }
}

