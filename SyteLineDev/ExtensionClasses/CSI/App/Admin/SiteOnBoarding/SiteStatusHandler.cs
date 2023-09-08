using System;
using CSI.Interfaces.Data;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ISiteStatusHandler
    {
        (string emailAddress, SiteStatus siteStatus) GetStateInfo(string site);

        void UpdateStateInfo(
            string emailAddress,
            string site,
            int pendingTableCount,
            int inProgressTableCount,
            int failedTableCount);
    }

    public class SiteStatusHandler : ISiteStatusHandler
    {
        private readonly ITmpSiteMgmtDataCRUD _tmpSiteMgmtDataCRUD;
        private readonly IEmail _email;

        public SiteStatusHandler(ITmpSiteMgmtDataCRUD tmpSiteMgmtDataCRUD, IEmail email)
        {
            _tmpSiteMgmtDataCRUD = tmpSiteMgmtDataCRUD;
            _email = email;
        }

        public (string emailAddress, SiteStatus siteStatus) GetStateInfo(string site)
        {
            var emailAddress = string.Empty;
            var siteStatus = SiteStatus.None;

            var stateInfoLoadResponse = _tmpSiteMgmtDataCRUD.ReadStateInfo(site);

            if (stateInfoLoadResponse.Items.Count == 1)
            {
                emailAddress = stateInfoLoadResponse.Items[0]
                    .GetValue<string>("emailAddress");
                siteStatus = (SiteStatus)Enum.Parse(
                    typeof(SiteStatus),
                    stateInfoLoadResponse.Items[0]
                        .GetValue<string>("status"));
            }

            return (emailAddress, siteStatus);
        }

        public void UpdateStateInfo(
            string emailAddress,
            string site,
            int pendingCount,
            int inProgressTableCount,
            int failedTableCount)
        {
            if (inProgressTableCount == 0)
            {
                if (failedTableCount != 0 || pendingCount != 0)
                {
                    _tmpSiteMgmtDataCRUD.UpdateStateInfo(site, SiteStatus.F);
                    _email.Send(
                        emailAddress,
                        "",
                        "",
                        "",
                        "Status Change Notification of Site On Boarding",
                        $"Process failed, {failedTableCount + pendingCount} tables failed.");
                }
                else
                {
                    _tmpSiteMgmtDataCRUD.DeleteStateInfo(site);
                    // TODO: Maybe we need delete the task and table_data table.
                    _email.Send(
                        emailAddress,
                        "",
                        "",
                        "",
                        "Status Change Notification of Site On Boarding",
                        $"Process succeed.");
                }
            }
        }
    }
}