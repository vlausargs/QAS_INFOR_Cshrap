using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantUDF
    {
        List<Dictionary<string, string>> ReadRelevantUDFData(string appViewName, int taskSize, string taskBookMark);
    }

    public class RelevantUDF : IRelevantUDF
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;

        public RelevantUDF(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
        }

        public List<Dictionary<string, string>> ReadRelevantUDFData(string appViewName, int taskSize, string taskBookMark)
        {
            var tableColumns = _tableColumnsCRUD.GetTableColumns("UserDefinedFields");
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadRelevantUDFData(
                taskSize,
                appViewName,
                taskBookMark,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response, tableColumns);
        }
    }
}
