using CSI.Data;
using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class ImportDataCRUD : IImportDataCRUD
    {
        private readonly IApplicationDB _applicationDB;
        private readonly ICollectionLoadBuilderRequestFactory _collectionLoadBuilderRequestFactory;
        private readonly ICollectionInsertRequestFactory _collectionInsertRequestFactory;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly ICollectionUpdateRequestFactory _collectionUpdateRequestFactory;
        private readonly IVariableUtil _variableUtil;

        public ImportDataCRUD(
            IApplicationDB applicationDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            IVariableUtil variableUtil)
        {
            _applicationDB = applicationDB;
            _collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            _collectionInsertRequestFactory = collectionInsertRequestFactory;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            _variableUtil = variableUtil;
        }

        public ICollectionLoadResponse ReadCollectionLoadResponseForImportData(
            Dictionary<string, object> importData)
        {
            var nonTableLoadRequest =
                _collectionLoadBuilderRequestFactory.Create(
                    columnExpressionByColumnName: importData);

            return _applicationDB.Load(nonTableLoadRequest);
        }

        public void InsertImportData(
            string tableName,
            ICollectionLoadResponse importDataCollectionLoadResponse)
        {
            var insertRequest = _collectionInsertRequestFactory.SQLInsert(
                tableName: tableName,
                items: importDataCollectionLoadResponse.Items);

            _applicationDB.Insert(insertRequest);
        }

        public void UpdateImportData(
            string tableName,
            string whereClause,
            Dictionary<string, string> nullableForeignColumns,
            Dictionary<string, object> nullableForeignKeys)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: nullableForeignColumns,
                tableName: tableName,
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(whereClause),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskLoadResponse = _applicationDB.Load(loadRequest);

            foreach (var foreignKey in nullableForeignKeys)
            {
                taskLoadResponse.Items[0].SetValue(foreignKey.Key, foreignKey.Value);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(
                tableName: tableName,
                items: taskLoadResponse.Items);

            _applicationDB.Update(requestUpdate);
        }
    }
}