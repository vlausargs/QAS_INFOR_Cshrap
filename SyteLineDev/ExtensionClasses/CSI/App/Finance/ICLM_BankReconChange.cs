//PROJECT NAME: Finance
//CLASS NAME: ICLM_BankReconChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface ICLM_BankReconChange
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode,
        string Infobar) CLM_BankReconChangeSp(
            string pBankCode,
            DateTime? pStartTransDate,
            DateTime? pEndTransDate,
            int? pStartTransNum,
            int? pEndTransNum,
            string pTypes,
            int? pCommit,
            string Infobar);
    }
}

