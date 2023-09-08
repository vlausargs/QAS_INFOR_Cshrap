//PROJECT NAME: CSICustomer
//CLASS NAME: CanImportPmtDeleted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICanImportPmtDeleted
    {
        int CanImportPmtDeletedSp(ARImportBatchIdType BatchID,
                                  ref FlagNyType DeleteEnabled);
    }

    public class CanImportPmtDeleted : ICanImportPmtDeleted
    {
        readonly IApplicationDB appDB;

        public CanImportPmtDeleted(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CanImportPmtDeletedSp(ARImportBatchIdType BatchID,
                                         ref FlagNyType DeleteEnabled)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CanImportPmtDeletedSp";

                appDB.AddCommandParameter(cmd, "BatchID", BatchID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DeleteEnabled", DeleteEnabled, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
