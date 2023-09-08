//PROJECT NAME: MG.MGCore
//CLASS NAME: IRetrieveSessionIdentity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IRetrieveSessionIdentity
    {
        (int? ReturnCode, long? Identity) RetrieveSessionIdentitySp(string TableName,
        long? Identity);
    }
}

