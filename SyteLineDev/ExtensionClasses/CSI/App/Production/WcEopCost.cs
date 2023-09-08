//PROJECT NAME: CSIProduct
//CLASS NAME: WcEopCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IWcEopCost
    {
        int WcEopCostSp(string StartingWc,
                        string EndingWc,
                        DateTime? PostThrough,
                        DateTime? TransDate,
                        ref string Infobar);
    }

    public class WcEopCost : IWcEopCost
    {
        readonly IApplicationDB appDB;

        public WcEopCost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int WcEopCostSp(string StartingWc,
                               string EndingWc,
                               DateTime? PostThrough,
                               DateTime? TransDate,
                               ref string Infobar)
        {
            WcType _StartingWc = StartingWc;
            WcType _EndingWc = EndingWc;
            DateType _PostThrough = PostThrough;
            DateType _TransDate = TransDate;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WcEopCostSp";

                appDB.AddCommandParameter(cmd, "StartingWc", _StartingWc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingWc", _EndingWc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PostThrough", _PostThrough, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
