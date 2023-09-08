using System.Collections.Generic;
using System.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public class WhereClauseForUpdate : IWhereClauseForUpdate
    {
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;

        public WhereClauseForUpdate(ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD)
        {
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
        }

        public string GetWhereClauseForUpdate(string tableName, Dictionary<string, object> row)
        {
            var primaryKeys = _tmpSiteMgmtTableDataCRUD.ReadTablePrimaryKeys(tableName).Items?
                .AsEnumerable()
                .Select(record => record.GetValue<string>(0)).ToList()
                .ToDictionary(key => key, key => row[key]);

            // FIXME: Is the pk DateTime type?
            var whereClause = primaryKeys.Keys.Aggregate(
                "1 = 1 ",
                (current, primaryKey) =>
                    current + $"AND {primaryKey} = '{primaryKeys[primaryKey]}'");

            return whereClause;
        }
    }
}