//PROJECT NAME: Admin
//CLASS NAME: RefreshWrapperFactory

using System;
using System.Collections.Generic;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshWrapperFactory
    {
        public IRefreshWrapper Create(IApplicationDB appDB, bool isProduction = false, bool isMingleUserSyncActive = false)
        {
            if (appDB == null) throw new ArgumentNullException(nameof(appDB));

            List<IRefreshIntegrationData> _lsIntegrations = new List<IRefreshIntegrationData>
            {
                new RefreshCCIData(appDB, isProduction),
                new RefreshDatalakeData(appDB),
                new RefreshFTKData(appDB),
                new RefreshIDMData(appDB),
                new RefreshIPFData(appDB),
                new RefreshMingleHomepagesData(appDB),
                new RefreshMingleIFSData(appDB, isMingleUserSyncActive),
                new RefreshTaxData(appDB, isProduction)
            };

            return Create(appDB, _lsIntegrations, isProduction, isMingleUserSyncActive);
        }

        public IRefreshWrapper Create(IApplicationDB appDB, List<IRefreshIntegrationData> lsIntegrations, bool isProduction = false, bool isMingleUserSyncActive = false)
        {
            if (appDB == null) throw new ArgumentNullException(nameof(appDB));
            if (lsIntegrations == null) throw new ArgumentNullException(nameof(lsIntegrations));

            var _RefreshWrapper = new RefreshWrapper(appDB, lsIntegrations, isProduction, isMingleUserSyncActive);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRefreshWrapperExt = timerfactory.Create<IRefreshWrapper>(_RefreshWrapper);

            return iRefreshWrapperExt;
        }
    }
}
