//PROJECT NAME: CSIMaterial
//CLASS NAME: TH_StockBalanceCons_InitData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITH_StockBalanceCons_InitData
    {
        int TH_StockBalanceCons_InitDataSP(IntType OverwriteExistingData,
                                           ref InfobarType Infobar);
    }

    public class TH_StockBalanceCons_InitData : ITH_StockBalanceCons_InitData
    {
        readonly IApplicationDB appDB;

        public TH_StockBalanceCons_InitData(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TH_StockBalanceCons_InitDataSP(IntType OverwriteExistingData,
                                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TH_StockBalanceCons_InitDataSP";

                appDB.AddCommandParameter(cmd, "OverwriteExistingData", OverwriteExistingData, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
