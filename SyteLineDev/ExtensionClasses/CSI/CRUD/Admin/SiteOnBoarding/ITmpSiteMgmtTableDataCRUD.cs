using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtTableDataCRUD
    {
        ICollectionLoadResponse ReadTableData(string site);

        ICollectionLoadResponse ReadTableDataCount(string tableName);

        void UpdateTableStatus(string site, string tableName, TableStatus tableStatus);

        void UpdateTableTotalTasksPlusOne(string site, string tableName);

        void UpdateTableLevelMinusOne(string site, string tableName);

        ICollectionLoadResponse ReadTablePrimaryKeys(string tableName);

        ICollectionLoadResponse SiteTableDataLoad(string site);

        void DeleteSiteTableData(ICollectionLoadResponse taskLoadResponse);

        ICollectionLoadResponse ReadAppTableAndTableReferenceInfo();
        ICollectionLoadResponse ReadPendingTableInfo(string site);

        ICollectionLoadResponse LoadTableData(
            string tableName,
            string site,
            string errorMsg,
            TableStatus status,
            int level,
            string referenced,
            string nullableColumn);

        void CreateTableData(ICollectionLoadResponse tableDataLoadResponse);

        ICollectionLoadResponse ReadNullableForeignKeyColumn(string tableName);


        string ReadTableNullableForeignKey(string site, string tableName);

        void UpdateTotalTasksOfTableData(string site, string tableName, int totalTasks);

        ICollectionLoadResponse ReadTableStateInfo(string site);

        bool ReadExistInProgressTable(string site);
    }
}