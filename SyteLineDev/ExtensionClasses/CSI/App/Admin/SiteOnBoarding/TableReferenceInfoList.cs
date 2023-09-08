using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITableReferenceInfoList
    {
        List<(string TableName, string AppViewName, int ReferenceCount, string Referenced)> GetTableReferenceInfoList();
    }

    public class TableReferenceInfoList : ITableReferenceInfoList
    {
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        private readonly IAppTableAndTableReferenceInfo _appTableAndTableReferenceInfo;

        public TableReferenceInfoList(ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD, IAppTableAndTableReferenceInfo appTableAndTableReferenceInfo)
        {
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
            _appTableAndTableReferenceInfo = appTableAndTableReferenceInfo;
        }

        public List<(string TableName, string AppViewName, int ReferenceCount, string Referenced)>
            GetTableReferenceInfoList()
        {
            ICollectionLoadResponse collectionLoadResponse;
            collectionLoadResponse = _tmpSiteMgmtTableDataCRUD.ReadAppTableAndTableReferenceInfo();
            return _appTableAndTableReferenceInfo.ConvertTableReferenceInfoToList(collectionLoadResponse);
        }
    }
}
