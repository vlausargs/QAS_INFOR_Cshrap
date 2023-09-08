//PROJECT NAME: MG.MGCore
//CLASS NAME: IAnticipateSessionIdentity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IAnticipateSessionIdentity
    {
        int? AnticipateSessionIdentitySp(string TableName);
    }
}

