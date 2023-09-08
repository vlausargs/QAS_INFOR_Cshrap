using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantSystemNotes
    {
        List<Dictionary<string, string>> ReadRelevantSystemNotesData(string appViewName, int taskSize, string taskBookMark);
    }

    public class RelevantSystemNotes : IRelevantSystemNotes
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;

        public RelevantSystemNotes(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
        }
        public List<Dictionary<string, string>> ReadRelevantSystemNotesData(string appViewName, int taskSize, string taskBookMark)
        {
            var tableColumns = _tableColumnsCRUD.GetTableColumns("SystemNotes");
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadRelevantSystemNotesData(
                taskSize,
                appViewName,
                taskBookMark,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response, tableColumns);
        }
    }
}

