namespace CSI.Admin.SiteOnBoarding
{
    public interface IDocumentObjectReferenceTask
    {
        void CreateTaskForDoc(string appViewName, string site, int taskNum, string docTaskBookmark);
    }

    public class DocumentObjectReferenceTask : IDocumentObjectReferenceTask
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;

        public DocumentObjectReferenceTask(ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
        }

        public void CreateTaskForDoc(
            string appViewName,
            string site,
            int taskNum,
            string docTaskBookmark)
        {
            _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.DocumentObjectReference)}-{appViewName}", site, taskNum, 
                docTaskBookmark, TaskStatus.P, TaskType.R);                                                        

            _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.DocumentObject)}-{appViewName}", site, taskNum,
                docTaskBookmark, TaskStatus.P, TaskType.R);
        }
    }
}
