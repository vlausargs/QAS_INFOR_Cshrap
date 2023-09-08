namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteTaskSpecificNotes
    {
        void CreateTaskForObjectNoteSpecificNotes(string appViewName, string site, int taskNum, int taskSize, string objectNoteTaskBookmark);
    }

    public class ObjectNoteTaskSpecificNotes : IObjectNoteTaskSpecificNotes
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IObjectNoteCRUD _objectNoteCRUD;

        public ObjectNoteTaskSpecificNotes(ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IObjectNoteCRUD objectNoteCRUD)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _objectNoteCRUD = objectNoteCRUD;
        }

        public void CreateTaskForObjectNoteSpecificNotes(
            string appViewName,
            string site,
            int taskNum,
            int taskSize,
            string objectNoteTaskBookmark)
        {
            if (_objectNoteCRUD.ReadRelevantSpecificNotesData(appViewName, objectNoteTaskBookmark, taskSize))
            {
                _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.SpecificNotes)}-{appViewName}", site, taskNum,
                    objectNoteTaskBookmark, TaskStatus.P, TaskType.R);
            }
        }

    }
}
