//PROJECT NAME: CSIMaterial
//CLASS NAME: ShipTransferProcessASN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IShipTransferProcessASN
    {
        int ShipTransferProcessASNSp(TrnNumType TrnNum,
                                     ref InfobarType Infobar);
    }

    public class ShipTransferProcessASN : IShipTransferProcessASN
    {
        readonly IApplicationDB appDB;

        public ShipTransferProcessASN(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ShipTransferProcessASNSp(TrnNumType TrnNum,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ShipTransferProcessASNSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
