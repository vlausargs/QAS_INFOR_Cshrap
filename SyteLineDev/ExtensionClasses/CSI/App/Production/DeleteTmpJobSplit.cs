//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteTmpJobSplit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IDeleteTmpJobSplit
    {
        int DeleteTmpJobSplitSp();
    }

    public class DeleteTmpJobSplit : IDeleteTmpJobSplit
    {
        readonly IApplicationDB appDB;

        public DeleteTmpJobSplit(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DeleteTmpJobSplitSp()
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteTmpJobSplitSp";

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
