//PROJECT NAME: CSICustomer
//CLASS NAME: DoLineValidForOrderShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IDoLineValidForOrderShip
    {
        int DoLineValidForOrderShipSp(string PDoNum,
                                      int? PDoLine,
                                      decimal? PQtyToShip,
                                      string PCoNum,
                                      short? PCoLine,
                                      short? PCoRelease,
                                      ref string Infobar);
    }

    public class DoLineValidForOrderShip : IDoLineValidForOrderShip
    {
        readonly IApplicationDB appDB;

        public DoLineValidForOrderShip(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DoLineValidForOrderShipSp(string PDoNum,
                                             int? PDoLine,
                                             decimal? PQtyToShip,
                                             string PCoNum,
                                             short? PCoLine,
                                             short? PCoRelease,
                                             ref string Infobar)
        {
            DoNumType _PDoNum = PDoNum;
            DoLineType _PDoLine = PDoLine;
            QtyUnitType _PQtyToShip = PQtyToShip;
            CoNumType _PCoNum = PCoNum;
            CoLineType _PCoLine = PCoLine;
            CoReleaseType _PCoRelease = PCoRelease;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoLineValidForOrderShipSp";

                appDB.AddCommandParameter(cmd, "PDoNum", _PDoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDoLine", _PDoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PQtyToShip", _PQtyToShip, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
