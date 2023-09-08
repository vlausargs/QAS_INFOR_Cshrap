using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtTask
    {
        void DeleteTask(string site);

        void CreateTask(string tableName,
            string site,
            int taskNum,
            string errorMsg,
            TaskStatus taskStatus,
            TaskType taskType);
    }
    public class TmpSiteMgmtTask : ITmpSiteMgmtTask
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;

        public TmpSiteMgmtTask(ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
        }

        public void DeleteTask(string site)
        {
            ICollectionLoadResponse collectionLoadReponse =
                _tmpSiteMgmtTaskCRUD.LoadTaskToDelete(site);
            _tmpSiteMgmtTaskCRUD.DeleteTask(collectionLoadReponse);
        }

        public void CreateTask(string tableName,
            string site,
            int taskNum,
            string errorMsg,
            TaskStatus taskStatus,
            TaskType taskType)
        {
            ICollectionLoadResponse collectionLoadReponse =
                _tmpSiteMgmtTaskCRUD.LoadTaskToCreate(tableName, site, taskNum, errorMsg, taskStatus, taskType);
            _tmpSiteMgmtTaskCRUD.CreateTask(collectionLoadReponse);
        }
    }
}
