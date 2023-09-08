namespace CSI.Admin.SiteOnBoarding
{
    public interface ISiteDataBoundary
    {
        (bool IsSuccess, string Infobar) PrepareTableList(string site);
    }

    public class SiteDataBoundary : ISiteDataBoundary
    {
        private readonly IIsFeatureActive _iIsFeatureActive;
        private readonly ITmpSiteMgmtTask _tmpSiteMgmtTask;
        private readonly ITmpSiteMgmtTableDataHandler _tmpSiteMgmtTableDataHandler;

        public SiteDataBoundary(ITmpSiteMgmtTableDataHandler tmpSiteMgmtTableDataHandler,
            ITmpSiteMgmtTask tmpSiteMgmtTask,
            IIsFeatureActive iIsFeatureActive)
        {
            _tmpSiteMgmtTableDataHandler = tmpSiteMgmtTableDataHandler;
            _tmpSiteMgmtTask = tmpSiteMgmtTask;
            _iIsFeatureActive = iIsFeatureActive;
        }

        public (bool IsSuccess, string Infobar) PrepareTableList(string site)
        {
            (int? returnCode, int? featureActive, string infobar) = _iIsFeatureActive.IsFeatureActiveSp(
                ProductName: "CSI",
                FeatureID: "RS9146",
                FeatureActive: 0,
                InfoBar: null);

            if (((returnCode ?? 0) != 0) || ((featureActive ?? 0) == 0))
                return (false, infobar);

            _tmpSiteMgmtTableDataHandler.ClearSiteMgmtTableData(site);
            _tmpSiteMgmtTask.DeleteTask(site);
            return _tmpSiteMgmtTableDataHandler.InitialSiteMgmtdata(site);
        }
    }
}