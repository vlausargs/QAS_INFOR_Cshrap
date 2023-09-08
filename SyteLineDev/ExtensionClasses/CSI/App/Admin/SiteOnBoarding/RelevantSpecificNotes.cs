using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantSpecificNotes
    {
        List<Dictionary<string, string>> ReadRelevantSpecificNotesData(string appViewName, int taskSize, string taskBookMark);
    }

    public class RelevantSpecificNotes : IRelevantSpecificNotes
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;

        public RelevantSpecificNotes(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
        }
        public List<Dictionary<string, string>> ReadRelevantSpecificNotesData(string appViewName, int taskSize, string taskBookMark)
        {
            var tableColumns = _tableColumnsCRUD.GetTableColumns("SpecificNotes");
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadRelevantSpecificNotesData(
                taskSize,
                appViewName,
                taskBookMark,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response, tableColumns);
        }
    }
}
