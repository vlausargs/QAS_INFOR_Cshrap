//PROJECT NAME: CSICustomer
//CLASS NAME: OrderShipPackNumValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IOrderShipPackNumValidation
    {
        int OrderShipPackNumValidationSp(string CoNum,
                                         short? CoLine,
                                         short? CoRelease,
                                         int? PackNum,
                                         decimal? QtyShipped,
                                         ref string Infobar);
    }

    public class OrderShipPackNumValidation : IOrderShipPackNumValidation
    {
        readonly IApplicationDB appDB;

        public OrderShipPackNumValidation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int OrderShipPackNumValidationSp(string CoNum,
                                                short? CoLine,
                                                short? CoRelease,
                                                int? PackNum,
                                                decimal? QtyShipped,
                                                ref string Infobar)
        {
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            CoReleaseType _CoRelease = CoRelease;
            PackNumType _PackNum = PackNum;
            QtyUnitType _QtyShipped = QtyShipped;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "OrderShipPackNumValidationSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
