//PROJECT NAME: Admin
//CLASS NAME: RefreshMingleHomepagesData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshMingleHomepagesData : IRefreshIntegrationData
    {
        IApplicationDB appDB;

        public RefreshMingleHomepagesData(IApplicationDB appDB)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public (int, string) PreRefresh()
        {
            // Default implementation (do nothing)
            return (0, string.Empty);
        }

        public int PostRefresh(string PreRefreshData)
        {
            // Default implementation (do nothing)
            return 0;
        }
    }
}
