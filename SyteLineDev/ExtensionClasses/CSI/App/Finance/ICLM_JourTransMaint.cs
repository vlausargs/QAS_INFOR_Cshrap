//PROJECT NAME: Finance
//CLASS NAME: ICLM_JourTransMaint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface ICLM_JourTransMaint
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode,
        string Infobar) CLM_JourTransMaintSp(
            string pJournalId,
            string Infobar);
    }
}

