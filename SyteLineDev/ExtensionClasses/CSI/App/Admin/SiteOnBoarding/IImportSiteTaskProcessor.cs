namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportSiteTaskProcessor
    {
        (bool isSuccess, string errorMsg) Process(
            string site,
            string logicalFolder,
            string taskRowPointer);
    }
}