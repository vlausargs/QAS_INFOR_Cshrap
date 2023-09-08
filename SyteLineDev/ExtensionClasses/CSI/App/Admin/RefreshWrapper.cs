//PROJECT NAME: Admin
//CLASS NAME: RefreshWrapper.cs

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshWrapper : IRefreshWrapper
    {
        IApplicationDB appDB;
        List<IRefreshIntegrationData> lsIntegrations;
        readonly bool isProduction;
        readonly bool isMingleUserSyncActive;

        public RefreshWrapper(IApplicationDB appDB, List<IRefreshIntegrationData> lsIntegrations, bool isProduction = false, bool isMingleUserSyncActive = false)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
            this.lsIntegrations = lsIntegrations ?? throw new ArgumentNullException(nameof(lsIntegrations));
            this.isProduction = isProduction;
            this.isMingleUserSyncActive = isMingleUserSyncActive;
        }

        public (int, string) PreRefresh()
        {
            // Create XElement to hold integration data
            XElement xmlPreRefreshData = new XElement("ListOfIntegrations");

            // Create child element for each integration
            foreach (IRefreshIntegrationData integration in lsIntegrations)
            {
                var Severity = 0;
                string integrationData = String.Empty;

                (Severity, integrationData) = integration.PreRefresh();
                xmlPreRefreshData.Add(new XElement("Integration", integrationData));
            }

            return (0, xmlPreRefreshData.ToString());
        }

        public int PostRefresh(string PreRefreshData)
        {
            // Create XElement from PreRefreshData
            XElement xmlPreRefreshData = null;
            try
            {
                xmlPreRefreshData = XElement.Parse(PreRefreshData, LoadOptions.PreserveWhitespace);
            }
            catch
            {
                return 16;
            }

            // Number of Integration elements must match number of members in lsIntegrations
            IList<XElement> indexedElements = xmlPreRefreshData.Elements("Integration").ToList();
            if (indexedElements.Count() != lsIntegrations.Count())
            {
                return 16;
            }

            // Call each integration with its appropriate saved data
            int i = 0;
            foreach (IRefreshIntegrationData integration in lsIntegrations)
            {
                integration.PostRefresh(indexedElements[i].Value);
                i++;
            }

            return 0;
        }
    }
}
