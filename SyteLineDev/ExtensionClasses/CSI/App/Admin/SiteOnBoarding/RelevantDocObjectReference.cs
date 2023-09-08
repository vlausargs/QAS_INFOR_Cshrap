using CSI.Data.CRUD;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantDocObjectReference
    {
        List<Dictionary<string, string>> ReadRelevantDocObjectReferenceData(string appViewName, int taskSize, string taskBookMark);
    }

    public class RelevantDocObjectReference : IRelevantDocObjectReference
    {
        private readonly ITableColumnsCRUD _tableColumnsCRUD;
        private readonly ITaskDataCollectorCRUD _taskdataCollectorCRUD;
        private readonly ICollectionToListConvertor _collectionToListConvertor;

        public RelevantDocObjectReference(ITableColumnsCRUD tableColumnsCRUD, ITaskDataCollectorCRUD taskdataCollectorCRUD, ICollectionToListConvertor collectionToListConvertor)
        {
            _tableColumnsCRUD = tableColumnsCRUD;
            _taskdataCollectorCRUD = taskdataCollectorCRUD;
            _collectionToListConvertor = collectionToListConvertor;
        }

        public List<Dictionary<string, string>> ReadRelevantDocObjectReferenceData(string appViewName, int taskSize, string taskBookMark)
        {
            var tableColumns = _tableColumnsCRUD.GetTableColumns("DocumentObjectReference");
            ICollectionLoadResponse response = _taskdataCollectorCRUD.ReadRelevantDocObjectReferenceData(
                taskSize,
                appViewName,
                taskBookMark,
                tableColumns);

            return _collectionToListConvertor.ConvertCollectionLoadResponseToList(response,tableColumns);
        }
    }
}
