//PROJECT NAME: MG.MGCore
//CLASS NAME: INextKey.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface INextKey
    {
        (int? ReturnCode, string KeyStr,
        string Infobar) NextKeySp(string TableName,
        string ColumnName,
        string Prefix,
        int? KeyLength,
        string Type,
        string Where = null,
        string TableName2 = null,
        string Where2 = null,
        string KeyStr = null,
        string Infobar = null);
    }
}

