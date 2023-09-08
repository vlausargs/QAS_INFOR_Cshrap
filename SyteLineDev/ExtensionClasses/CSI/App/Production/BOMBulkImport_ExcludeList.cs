//PROJECT NAME: CSIProduct
//CLASS NAME: BOMBulkImport_ExcludeList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IBOMBulkImport_ExcludeList
    {
        int BOMBulkImport_ExcludeListSp(TableNameType TableName,
                                        ref InfobarType ExcludeList);
    }

    public class BOMBulkImport_ExcludeList : IBOMBulkImport_ExcludeList
    {
        readonly IApplicationDB appDB;

        public BOMBulkImport_ExcludeList(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int BOMBulkImport_ExcludeListSp(TableNameType TableName,
                                               ref InfobarType ExcludeList)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BOMBulkImport_ExcludeListSp";

                appDB.AddCommandParameter(cmd, "TableName", TableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExcludeList", ExcludeList, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
