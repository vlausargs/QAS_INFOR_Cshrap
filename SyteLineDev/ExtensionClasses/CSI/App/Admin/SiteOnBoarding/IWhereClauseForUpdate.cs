using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IWhereClauseForUpdate
    {
        string GetWhereClauseForUpdate(string tableName, Dictionary<string, object> row);
    }
}