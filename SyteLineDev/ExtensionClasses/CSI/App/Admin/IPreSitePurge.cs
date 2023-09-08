//PROJECT NAME: Admin
//CLASS NAME: IPreSitePurge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
    public interface IPreSitePurge
    {
        (int? ReturnCode,
        string Infobar) PreSitePurgeSp(string DeleteSite,
        int? IsRetry = 0,
        string NotificationEmail = null,
        string Infobar = null);
    }
}

