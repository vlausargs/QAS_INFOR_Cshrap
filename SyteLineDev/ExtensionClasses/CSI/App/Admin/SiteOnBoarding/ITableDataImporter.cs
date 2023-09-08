namespace CSI.Admin.SiteOnBoarding
{
    public interface ITableDataImporter
    {
        (bool IsSuccess, string ErrorMsg) Process(string site, string logicFolderName, string taskRowPointer);
    }
}