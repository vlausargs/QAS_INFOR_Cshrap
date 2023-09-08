using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantObjectNotes
    {
        List<Dictionary<string, string>> ReadRelevantObjectNotesData(string appViewName, int taskSize, string taskBookMark);
    }

    public class RelevantObjectNotes : IRelevantObjectNotes
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;

        public RelevantObjectNotes(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
        }
        public List<Dictionary<string, string>> ReadRelevantObjectNotesData(string appViewName, int taskSize, string taskBookMark)
        {
            var tableColumns = _tableColumnsCRUD.GetTableColumns("ObjectNotes");
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadRelevantObjectNotesData(
                taskSize,
                appViewName,
                taskBookMark,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response, tableColumns);
        }
    }
}
