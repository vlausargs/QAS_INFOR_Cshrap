
using CSI.Data.SQL.UDDT;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IPendingTable
    {
        (string tableName, string appViewName) ReadPendingTableInfo(string site);
    }

    public class PendingTable : IPendingTable
    {
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        public PendingTable(ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD)
        {
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
        }

        public (string tableName, string appViewName) ReadPendingTableInfo(string site)
        {
            var result = _tmpSiteMgmtTableDataCRUD.ReadPendingTableInfo(site);
            if (result.Items.Count != 0)
            {
                var tableName = result.Items[0].GetValue<TableNameType>(0);
                var appViewName = result.Items[0].GetValue<TableNameType>(1);
                _tmpSiteMgmtTableDataCRUD.UpdateTableStatus(site, appViewName, TableStatus.I);
                return (tableName, appViewName);
            }   
            return (string.Empty, string.Empty);
        }
    }
}
