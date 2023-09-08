namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteTaskUserNotes
    {
        void CreateTaskForObjectNoteUserNotes(string appViewName, string site, int taskNum, int taskSize, string objectNoteTaskBookmark);
    }

    public class ObjectNoteTaskUserNotes : IObjectNoteTaskUserNotes
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IObjectNoteCRUD _objectNoteCRUD;

        public ObjectNoteTaskUserNotes(ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IObjectNoteCRUD objectNoteCRUD)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _objectNoteCRUD = objectNoteCRUD;
        }

        public void CreateTaskForObjectNoteUserNotes(
            string appViewName,
            string site,
            int taskNum,
            int taskSize,
            string objectNoteTaskBookmark)
        {
            if (_objectNoteCRUD.ReadRelevantUserNotesData(appViewName, objectNoteTaskBookmark, taskSize))
            {
                _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.UserNotes)}-{appViewName}", site, taskNum,
                    objectNoteTaskBookmark, TaskStatus.P, TaskType.R);
            }
        }

    }
}
