//PROJECT NAME: MG.MGCore
//CLASS NAME: ISetNextKey.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ISetNextKey
    {
        (int? ReturnCode, string KeyStr,
        string Infobar) SetNextKeySp(string TableName,
        string ColumnName,
        string Prefix,
        int? KeyLength,
        string Type,
        string SubKey = null,
        string TableName2 = null,
        string SubKey2 = null,
        string KeyStr = null,
        string Infobar = null,
        int? Increment = 1);
    }
}

