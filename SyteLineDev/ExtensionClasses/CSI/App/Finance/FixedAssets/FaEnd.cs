//PROJECT NAME: CSIFinance
//CLASS NAME: FaEnd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IFaEnd
    {
        int FaEndSp(FaNumType AssetNumStart,
                    FaNumType AssetNumEnd,
                    ref InfobarType Infobar);
    }

    public class FaEnd : IFaEnd
    {
        readonly IApplicationDB appDB;

        public FaEnd(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int FaEndSp(FaNumType AssetNumStart,
                           FaNumType AssetNumEnd,
                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FaEndSp";

                appDB.AddCommandParameter(cmd, "AssetNumStart", AssetNumStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AssetNumEnd", AssetNumEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}