namespace CSI.Admin.SiteOnBoarding
{
    public class SiteImportTaskDistributor : ISiteImportTaskDistributor
    {
        private readonly IFileHandler _fileHandler;
        private readonly IImportTaskHandler _importTaskHandler;
        private readonly ILogicalFolderCRUD _logicalFolderCRUD;
        private readonly IImportSiteTaskListener _importSiteTaskListener;

        public SiteImportTaskDistributor(
            IFileHandler fileHandler,
            IImportTaskHandler importTaskHandler,
            ILogicalFolderCRUD logicalFolderCRUD,
            IImportSiteTaskListener importSiteTaskListener)
        {
            _fileHandler = fileHandler;
            _importTaskHandler = importTaskHandler;
            _logicalFolderCRUD = logicalFolderCRUD;
            _importSiteTaskListener = importSiteTaskListener;
        }

        public (bool IsSuccess, string ErrorMsg) DistributeTask(
            string site,
            string logicalFolder)
        {
            var (serverName, fileSpec) =
                _logicalFolderCRUD.ReadLogicalFolderInfo(logicalFolder);

            var (getFileInfoListIsSuccess, getFileInfoListErrorMsg, fileInfoList) =
                _fileHandler.GetFileInfoList(fileSpec, serverName, logicalFolder);

            if (!getFileInfoListIsSuccess)
            {
                return (false, getFileInfoListErrorMsg);
            }

            var (isSuccess, errorMsg) = _importTaskHandler.DistributeTask(
                site,
                logicalFolder,
                fileSpec,
                serverName,
                fileInfoList);

            if (!isSuccess)
            {
                _importSiteTaskListener.ProcessAfterFinish(site);
            }

            return (isSuccess, errorMsg);
        }
    }
}