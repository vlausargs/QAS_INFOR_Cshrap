using CSI.Data.CRUD;
using System.Collections.Generic;


namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantNoteHeader
    {
        List<Dictionary<string, string>> ReadRelevantNoteHeadersData(string appViewName, int taskSize, string taskBookMark);
    }

    public class RelevantNoteHeader : IRelevantNoteHeader
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;

        public RelevantNoteHeader(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
        }

        public List<Dictionary<string, string>> ReadRelevantNoteHeadersData(string appViewName, int taskSize, string taskBookMark)
        {
            var tableColumns = _tableColumnsCRUD.GetTableColumns("NoteHeaders");
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadRelevantNoteHeadersData(
                taskSize,
                appViewName,
                taskBookMark,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response, tableColumns);
        }
    }
}
