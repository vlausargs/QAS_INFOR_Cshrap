using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;
using System.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITaskDistributionBookmarkRowDataCRUD
    {
        ICollectionLoadResponse ReadBookmarkRowData(int origin, string tableName, string whereClause, List<string> primaryKeys);
    }

    public class TaskDistributionBookmarkRowDataCRUD : ITaskDistributionBookmarkRowDataCRUD
    {
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IApplicationDB _applicationDB;

        public TaskDistributionBookmarkRowDataCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IApplicationDB applicationDB)
        {
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _applicationDB = applicationDB;
        }

        public ICollectionLoadResponse ReadBookmarkRowData(
            int origin,
            string tableName,
            string whereClause,
            List<string> primaryKeys)
        {
            var columnDictionary = primaryKeys.Select((s, i) => new { s, i }).ToDictionary(x => x.s, x => x.s);

            var loadRequest = _collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: columnDictionary,
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: tableName,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(whereClause),
                orderByClause: _collectionLoadRequestFactory.Clause($"{string.Join(",", primaryKeys)} OFFSET {origin} ROWS FETCH NEXT 1 ROWS ONLY"));
            return _applicationDB.Load(loadRequest);            
        }

    }
}
