using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportDataCRUD
    {
        ICollectionLoadResponse ReadCollectionLoadResponseForImportData(
            Dictionary<string, object> importData);

        void InsertImportData(
            string tableName,
            ICollectionLoadResponse importDataCollectionLoadResponse);

        void UpdateImportData(
            string tableName,
            string whereClause,
            Dictionary<string,string> nullableForeignColumns,
            Dictionary<string,object> nullableForeignKeys);
    }
}