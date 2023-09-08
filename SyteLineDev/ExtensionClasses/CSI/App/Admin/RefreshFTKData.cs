//PROJECT NAME: Admin
//CLASS NAME: RefreshFTKData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshFTKData : IRefreshIntegrationData
    {
        IApplicationDB appDB;

        public RefreshFTKData(IApplicationDB appDB)
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
