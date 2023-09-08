namespace CSI.Admin.SiteOnBoarding
{
    public class ImportSiteTaskProcessor : IImportSiteTaskProcessor
    {
        private readonly ISiteImportTaskDistributor _siteImportTaskDistributor;
        private readonly ITableDataImporter _tableDataImporter;
        private readonly IIsFeatureActive _isFeatureActive;

        public ImportSiteTaskProcessor(
            ISiteImportTaskDistributor siteImportTaskDistributor,
            ITableDataImporter tableDataImporter,
            IIsFeatureActive isFeatureActive)
        {
            _siteImportTaskDistributor = siteImportTaskDistributor;
            _tableDataImporter = tableDataImporter;
            _isFeatureActive = isFeatureActive;
        }

        public (bool isSuccess, string errorMsg) Process(
            string site,
            string logicalFolder,
            string taskRowPointer)
        {
            var (returnCode, featureActive, infobar) =
                _isFeatureActive.IsFeatureActiveSp(
                    ProductName: "CSI",
                    FeatureID: "RS9146",
                    FeatureActive: 0,
                    InfoBar: null);

            if ((returnCode ?? 0) != 0 || (featureActive ?? 0) == 0)
                return (false, infobar);

            return string.IsNullOrWhiteSpace(taskRowPointer)
                ? _siteImportTaskDistributor.DistributeTask(site, logicalFolder)
                : _tableDataImporter.Process(site, logicalFolder, taskRowPointer);
        }
    }
}