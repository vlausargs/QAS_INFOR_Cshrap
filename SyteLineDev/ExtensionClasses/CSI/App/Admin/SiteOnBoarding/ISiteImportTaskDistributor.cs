namespace CSI.Admin.SiteOnBoarding
{
    public interface ISiteImportTaskDistributor
    {
        (bool IsSuccess, string ErrorMsg) DistributeTask(
            string site,
            string logicalFolder);
    }
}