namespace CSI.Admin.SiteOnBoarding
{
    public class SiteTaskListener : ISiteTaskListener
    {
        private readonly ITableStatusHandler _tableStatusHandler;
        private readonly ISiteStatusHandler _siteStatusHandler;

        public SiteTaskListener(
            ITableStatusHandler TableStatusHandler,
            ISiteStatusHandler SiteStatusHandler)
        {
            _tableStatusHandler = TableStatusHandler;
            _siteStatusHandler = SiteStatusHandler;
        }

        public void UpdateStateInfoAfterFinished(string site, string emailAddress)
        {
            var (pendingCount, inProgressCount, failedCount) =
                _tableStatusHandler.GetTableStateInfo(site);

            _siteStatusHandler.UpdateStateInfo(
                emailAddress,
                site,
                pendingCount,
                inProgressCount,
                failedCount);
        }
    }
}