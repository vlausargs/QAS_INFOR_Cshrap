//PROJECT NAME: MG.MGCore
//CLASS NAME: IInsertEventInputParameter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IInsertEventInputParameter
    {
        int? InsertEventInputParameterSp(Guid? EventParmId,
        string Name,
        string Value,
        int? IsOutput = 0);
    }
}

