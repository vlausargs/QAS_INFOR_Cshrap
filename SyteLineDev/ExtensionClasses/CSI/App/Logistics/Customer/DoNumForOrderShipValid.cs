//PROJECT NAME: CSICustomer
//CLASS NAME: DoNumForOrderShipValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IDoNumForOrderShipValid
    {
        int DoNumForOrderShipValidSp(string PDoNum,
                                     decimal? PQtyToShip,
                                     string PCoNum,
                                     short? PCoLine,
                                     short? PCoRelease,
                                     ref string Infobar);
    }

    public class DoNumForOrderShipValid : IDoNumForOrderShipValid
    {
        readonly IApplicationDB appDB;

        public DoNumForOrderShipValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DoNumForOrderShipValidSp(string PDoNum,
                                            decimal? PQtyToShip,
                                            string PCoNum,
                                            short? PCoLine,
                                            short? PCoRelease,
                                            ref string Infobar)
        {
            DoNumType _PDoNum = PDoNum;
            QtyUnitType _PQtyToShip = PQtyToShip;
            CoNumType _PCoNum = PCoNum;
            CoLineType _PCoLine = PCoLine;
            CoReleaseType _PCoRelease = PCoRelease;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoNumForOrderShipValidSp";

                appDB.AddCommandParameter(cmd, "PDoNum", _PDoNum, ParameterDirection.Input);
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
