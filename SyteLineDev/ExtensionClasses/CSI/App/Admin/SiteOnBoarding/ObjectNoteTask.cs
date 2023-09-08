namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteTask
    {
        void CreateTaskForObjectNote(string appViewName, string site, int taskNum, int taskSize, string objectNoteTaskBookmark);
    }

    public class ObjectNoteTask : IObjectNoteTask
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IObjectNoteTaskSpecificNotes _objectNoteTaskSpecificNotes;
        private readonly IObjectNoteTaskSystemNotes _objectNoteTaskSystemNotes;
        private readonly IObjectNoteTaskUserNotes _objectNoteTaskUserNotes;

        public ObjectNoteTask(ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IObjectNoteTaskSpecificNotes objectNoteTaskSpecificNotes,
            IObjectNoteTaskSystemNotes objectNoteTaskSystemNotes,
            IObjectNoteTaskUserNotes objectNoteTaskUserNotes)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _objectNoteTaskSpecificNotes = objectNoteTaskSpecificNotes;
            _objectNoteTaskSystemNotes = objectNoteTaskSystemNotes;
            _objectNoteTaskUserNotes = objectNoteTaskUserNotes;
        }

        public void CreateTaskForObjectNote(
            string appViewName,
            string site,
            int taskNum,
            int taskSize,
            string objectNoteTaskBookmark)
        {
            _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.ObjectNotes)}-{appViewName}", site, taskNum,
                objectNoteTaskBookmark, TaskStatus.P, TaskType.R);

            _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.NoteHeaders)}-{appViewName}", site, taskNum,
                objectNoteTaskBookmark, TaskStatus.P, TaskType.R);

            _objectNoteTaskSpecificNotes.CreateTaskForObjectNoteSpecificNotes(appViewName, site, taskNum, taskSize, objectNoteTaskBookmark);

            _objectNoteTaskSystemNotes.CreateTaskForObjectNoteSystemNotes(appViewName, site, taskNum, taskSize, objectNoteTaskBookmark);

            _objectNoteTaskUserNotes.CreateTaskForObjectNoteUserNotes(appViewName, site, taskNum, taskSize, objectNoteTaskBookmark);
        }
    }

}
