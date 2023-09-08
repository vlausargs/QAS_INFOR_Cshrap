namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportSiteTaskProcessor
    {
        (bool isSuccess, string errorMsg) Process(string site, int taskSize, string targetFileType, string logicalFolder, string taskRowPointer);
    }

    public class ExportSiteTaskProcessor : IExportSiteTaskProcessor
    {
        private readonly ISiteExportTaskDistributor _siteExportTaskDistributor;
        private readonly ITableDataExporter _tableDataExporter;
        readonly IIsFeatureActive _isFeatureActive;

        public ExportSiteTaskProcessor(ISiteExportTaskDistributor siteExportTaskDistributor, ITableDataExporter tableDataExporter, IIsFeatureActive isFeatureActive)
        {
            _siteExportTaskDistributor = siteExportTaskDistributor;
            _tableDataExporter = tableDataExporter;
            _isFeatureActive = isFeatureActive;
        }

        public (bool isSuccess, string errorMsg) Process(string site, int taskSize, string targetFileType, string logicalFolder, string taskRowPointer)
        {
            (int? returnCode, int? featureActive, string infobar) = _isFeatureActive.IsFeatureActiveSp(
                ProductName: "CSI",
                FeatureID: "RS9146",
                FeatureActive: 0,
                InfoBar: null);

            if (((returnCode ?? 0) != 0) || ((featureActive ?? 0) == 0))
                return (false, infobar);

            return string.IsNullOrWhiteSpace(taskRowPointer)
                ? _siteExportTaskDistributor.DistributeTask(site, taskSize)
                : _tableDataExporter.ProcessAndUpdateTaskStatusIfFailed(site, taskSize, targetFileType, logicalFolder, taskRowPointer);
        }
    }
}
