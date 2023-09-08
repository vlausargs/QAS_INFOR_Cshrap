using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtTableDataHandler
    {
        void ClearSiteMgmtTableData(string site);

        (bool IsSuccess, string Infobar) InitialSiteMgmtdata(string site);
    }
    public class TmpSiteMgmtTableDataHandler : ITmpSiteMgmtTableDataHandler
    {
        private readonly ITmpSiteMgmtTableDataProcessor _tmpSiteMgmtTableDataProcessor;
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        private readonly ITableReferenceInfoList _tableReferenceInfoList;

        public TmpSiteMgmtTableDataHandler(ITmpSiteMgmtTableDataProcessor tmpSiteMgmtTableDataProcessor,
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD,
            ITableReferenceInfoList tableReferenceInfoList)
        {
            _tmpSiteMgmtTableDataProcessor = tmpSiteMgmtTableDataProcessor;
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
            _tableReferenceInfoList = tableReferenceInfoList;
        }

        public void ClearSiteMgmtTableData(string site)
        {
            ICollectionLoadResponse collectionLoadResponse;
            collectionLoadResponse = _tmpSiteMgmtTableDataCRUD.SiteTableDataLoad(site);
            _tmpSiteMgmtTableDataCRUD.DeleteSiteTableData(collectionLoadResponse);
        }

        public (bool IsSuccess, string Infobar) InitialSiteMgmtdata(string site)
        {
            var referencedTableDataTables = _tableReferenceInfoList.GetTableReferenceInfoList();
            return _tmpSiteMgmtTableDataProcessor.CreateTableData(referencedTableDataTables, site);
        }
    }
}
