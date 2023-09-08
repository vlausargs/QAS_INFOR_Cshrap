using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public interface INullableForeignKeyColumnAcquisition
    {
        string GetNullableForeignKeyColumn(string tableName);
    }

    public class NullableForeignKeyColumnAcquisition : INullableForeignKeyColumnAcquisition
    {
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;

        public NullableForeignKeyColumnAcquisition(ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD)
        {
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
        }

        public string GetNullableForeignKeyColumn(string tableName)
        {
            ICollectionLoadResponse collectionLoadResponse;
            var nullableColumn = string.Empty;
            collectionLoadResponse = _tmpSiteMgmtTableDataCRUD.ReadNullableForeignKeyColumn(tableName);

            if (collectionLoadResponse.Items.Count == 1)
            {
                nullableColumn = collectionLoadResponse.Items[0].GetValue<string>("NullableForeignKey");
            }
            return nullableColumn;
        }
    }
}
