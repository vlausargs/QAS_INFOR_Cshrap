using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ICommonTaskTableData
    {
        List<Dictionary<string, string>> ReadCommonTaskTableData(string appViewName, int taskSize, string tableName, string taskBookMark);
    }

    public class CommonTaskTableData : ICommonTaskTableData
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;
        private readonly ITmpSiteMgmtTableData _tmpSiteMgmtTableData;

        public CommonTaskTableData(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor, ITmpSiteMgmtTableData tmpSiteMgmtTableData)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
            _tmpSiteMgmtTableData = tmpSiteMgmtTableData;
        }

        public List<Dictionary<string, string>> ReadCommonTaskTableData(string appViewName, int taskSize, string tableName, string taskBookMark)
        {
            var primaryKeys = _tmpSiteMgmtTableData.GetTablePrimaryKeys(tableName);
            var tableColumns = _tableColumnsCRUD.GetTableColumns(appViewName);
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadCommonTableData(
                taskSize,
                appViewName,
                taskBookMark,
                primaryKeys,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response, tableColumns);
        }
    }
}
