namespace CSI.Admin.SiteOnBoarding
{
    public interface IDocumentObjectReference
    {
        bool CreateTaskList(string appViewName, string site, int taskSize);
    }

    public class DocumentObjectReference : IDocumentObjectReference
    {
        private readonly IDocumentObjectReferenceCRUD _documentObjectReferenceCRUD;
        private readonly IDocumentObjectReferenceCreateTaskWithWhereClause _documentObjectReferenceCreateTaskWithWhereClause;

        public DocumentObjectReference(IDocumentObjectReferenceCRUD documentObjectReferenceCRUD,
            IDocumentObjectReferenceCreateTaskWithWhereClause documentObjectReferenceCreateTaskWithWhereClause)
        {
            _documentObjectReferenceCRUD = documentObjectReferenceCRUD;
            _documentObjectReferenceCreateTaskWithWhereClause = documentObjectReferenceCreateTaskWithWhereClause;
        }

        public bool CreateTaskList(
            string appViewName,
            string site,
            int taskSize)
        {
            var tableRowsCount = _documentObjectReferenceCRUD.ReadRelevantDocObjectReferenceCount(appViewName);

            // No record means we needn't process this relevant table
            if (tableRowsCount <= 0) return true;

            _documentObjectReferenceCreateTaskWithWhereClause.CreateDocumentObjectReferenceTasks(appViewName, site, taskSize, tableRowsCount);

            return true;
        }
    }
}