//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROLineTransValidQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROLineTransValidQty
    {
        int SSSFSSROLineTransValidQtySp(FSSRONumType SRONum,
                                        FSSROLineType SROLine,
                                        QtyUnitType QtyConv,
                                        ref Infobar Infobar);
    }

    public class SSSFSSROLineTransValidQty : ISSSFSSROLineTransValidQty
    {
        readonly IApplicationDB appDB;

        public SSSFSSROLineTransValidQty(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROLineTransValidQtySp(FSSRONumType SRONum,
                                               FSSROLineType SROLine,
                                               QtyUnitType QtyConv,
                                               ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROLineTransValidQtySp";

                appDB.AddCommandParameter(cmd, "SRONum", SRONum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SROLine", SROLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyConv", QtyConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
