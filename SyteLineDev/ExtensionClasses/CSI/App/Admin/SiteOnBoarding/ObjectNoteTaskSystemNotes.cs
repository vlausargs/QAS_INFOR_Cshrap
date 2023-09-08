namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteTaskSystemNotes
    {
        void CreateTaskForObjectNoteSystemNotes(string appViewName, string site, int taskNum, int taskSize, string objectNoteTaskBookmark);
    }

    public class ObjectNoteTaskSystemNotes : IObjectNoteTaskSystemNotes
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IObjectNoteCRUD _objectNoteCRUD;

        public ObjectNoteTaskSystemNotes(ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IObjectNoteCRUD objectNoteCRUD)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _objectNoteCRUD = objectNoteCRUD;
        }

        public void CreateTaskForObjectNoteSystemNotes(
            string appViewName,
            string site,
            int taskNum,
            int taskSize,
            string objectNoteTaskBookmark)
        {
            if (_objectNoteCRUD.ReadRelevantSystemNotesData(appViewName, objectNoteTaskBookmark, taskSize))
            {
                _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.SystemNotes)}-{appViewName}", site, taskNum,
                    objectNoteTaskBookmark, TaskStatus.P, TaskType.R);
            }
        }

    }
}
