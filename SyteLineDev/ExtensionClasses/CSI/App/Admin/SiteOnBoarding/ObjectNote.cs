namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNote
    {
        bool CreateTaskList(string appViewName, string site, int taskSize);
    }

    public class ObjectNote : IObjectNote
    {
        private readonly IObjectNoteCRUD _objectNoteCRUD;
        private readonly IObjectNoteCreateTaskWithWhereClause _objectNoteCreateTaskWithWhereClause;

        public ObjectNote(IObjectNoteCRUD objectNoteCRUD,
            IObjectNoteCreateTaskWithWhereClause objectNoteCreateTaskWithWhereClause)
        {
            _objectNoteCRUD = objectNoteCRUD;
            _objectNoteCreateTaskWithWhereClause = objectNoteCreateTaskWithWhereClause;
        }

        public bool CreateTaskList(
            string appViewName,
            string site,
            int taskSize)
        {
            var tableRowsCount = _objectNoteCRUD.ReadRelevantObjectNotesCount(appViewName);

            // No record means we needn't process this relevant table
            if (tableRowsCount <= 0) return true;

            _objectNoteCreateTaskWithWhereClause.CreateObjectNoteTasks(appViewName, site, taskSize, tableRowsCount);

            return true;
        }
    }
}
