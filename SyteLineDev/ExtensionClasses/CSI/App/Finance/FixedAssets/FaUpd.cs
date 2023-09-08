//PROJECT NAME: CSIFinance
//CLASS NAME: FaUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IFaUpd
    {
        int FaUpdSp(CurrentDateType TPostDate,
                    IntType ErrorCnt,
                    ref InfobarType Infobar);
    }

    public class FaUpd : IFaUpd
    {
        readonly IApplicationDB appDB;

        public FaUpd(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int FaUpdSp(CurrentDateType TPostDate,
                           IntType ErrorCnt,
                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FaUpdSp";

                appDB.AddCommandParameter(cmd, "TPostDate", TPostDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ErrorCnt", ErrorCnt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
