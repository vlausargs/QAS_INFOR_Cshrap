using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtTableData
    {
        List<string> ReadTableData(string site);

        long ReadTableDataCount(string tableName);

        List<string> GetTablePrimaryKeys(string tableName);

        void CreateSiteMgmtTableData(string appViewName,
            string site,
            string errorMsg,
            TableStatus status,
            int referenceCount,
            string referenced,
            string nullableColumn);
    }

    public class TmpSiteMgmtTableData : ITmpSiteMgmtTableData
    {
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;

        public TmpSiteMgmtTableData(ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD)
        {
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
        }

        public List<string> ReadTableData(string site)
        {
            ICollectionLoadResponse taskLoadResponse = 
                _tmpSiteMgmtTableDataCRUD.ReadTableData(site);
            return taskLoadResponse.Items.AsEnumerable()
                .Select(r => r.GetValue<string>(0))
                .ToList();
        }

        public long ReadTableDataCount(string tableName)
        {
            long? tableDataCount = null;
            ICollectionLoadResponse taskLoadResponse =
            _tmpSiteMgmtTableDataCRUD.ReadTableDataCount(tableName);
            if (taskLoadResponse.Items.Count > 0)
                tableDataCount = taskLoadResponse.Items[0].GetValue<long?>(0);

            return tableDataCount ?? 0;
        }

        public List<string> GetTablePrimaryKeys(string tableName)
        {
            var response = _tmpSiteMgmtTableDataCRUD.ReadTablePrimaryKeys(tableName);

            if (response.Items.Count == 0)
                throw new Exception($@"Table {tableName} doesn't have Primary Keys.");

            return response.Items.AsEnumerable().Select(record => record.GetValue<string>(0)).ToList();
        }

        public void CreateSiteMgmtTableData(string appViewName,
            string site,
            string errorMsg,
            TableStatus status,
            int level,
            string referenced,
            string nullableColumn)
        {
            ICollectionLoadResponse collectionLoadResponse;
            collectionLoadResponse = _tmpSiteMgmtTableDataCRUD.LoadTableData(
                                appViewName,
                                site,
                                errorMsg,
                                status,
                                level,
                                referenced,
                                nullableColumn);

            _tmpSiteMgmtTableDataCRUD.CreateTableData(collectionLoadResponse);
        }
    }
}
