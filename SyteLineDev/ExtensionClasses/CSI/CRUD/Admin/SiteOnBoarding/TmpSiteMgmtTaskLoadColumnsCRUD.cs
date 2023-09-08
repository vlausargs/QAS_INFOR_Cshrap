using CSI.Data;
using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtTaskLoadColumnsCRUD
    {
        ICollectionLoadResponse LoadColumnsWithBookmark(string tableName, string site, int taskNum, string bookMark, TaskStatus taskStatus, TaskType taskType);
        ICollectionLoadResponse LoadCompletedTasks(string rowPointer);
    }

    public class TmpSiteMgmtTaskLoadColumnsCRUD : ITmpSiteMgmtTaskLoadColumnsCRUD
    {
        private readonly ICollectionLoadBuilderRequestFactory _collectionLoadBuilderRequestFactory;
        private readonly IApplicationDB _applicationDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;

        public TmpSiteMgmtTaskLoadColumnsCRUD(ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            IApplicationDB applicationDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IVariableUtil variableUtil)
        {
            _collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            _applicationDB = applicationDB;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _variableUtil = variableUtil;
        }

        public ICollectionLoadResponse LoadColumnsWithBookmark(
            string tableName,
            string site,
            int taskNum,
            string bookMark,
            TaskStatus taskStatus,
            TaskType taskType)
        {
            var nonTableLoadRequest = _collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    {"site", site},
                    {"table_name", tableName},
                    {"task_num", taskNum},
                    {"task_status", taskStatus.ToString("G")},
                    {"book_mark", bookMark},
                    {"task_type", taskType.ToString("G")}
                });
            return _applicationDB.Load(nonTableLoadRequest);
        }

        public ICollectionLoadResponse LoadCompletedTasks(string rowPointer)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"RowPointer", "RowPointer"}
                },
                tableName: "tmp_site_mgmt_task",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"tmp_site_mgmt_task.RowPointer = {_variableUtil.GetQuotedValue(rowPointer)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            return _applicationDB.Load(loadRequest);
        }
    }
}
