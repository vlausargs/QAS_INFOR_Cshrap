using CSI.Data.CRUD;
using System.Collections.Generic;


namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantDocObject
    {
        List<Dictionary<string, string>> ReadRelevantDocObjectData(string appViewName, int taskSize, string taskBookMark);
    }

    public class RelevantDocObject : IRelevantDocObject
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;

        public RelevantDocObject(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
        }

        public List<Dictionary<string, string>> ReadRelevantDocObjectData(string appViewName, int taskSize, string taskBookMark)
        {
            var tableColumns = _tableColumnsCRUD.GetTableColumns("DocumentObject");
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadRelevantDocObjectData(
                taskSize,
                appViewName,
                taskBookMark,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response, tableColumns);
        }
    }
}
