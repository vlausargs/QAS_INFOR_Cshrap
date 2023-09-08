//PROJECT NAME: Finance
//CLASS NAME: ICCIGetLastTransInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
    public interface ICCIGetLastTransInfo
    {
            (int? ReturnCode,
            decimal? GatewayTransNum,
            int? Success,
        string Infobar) CCIGetLastTransInfoSp(
            string CardSystemId,
            string CardSystem,
            string RefType,
            string TransType,
            string OrdInvNum,
            decimal? GatewayTransNum,
            int? Success,
            string Infobar);
    }
}

