//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMQtyShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSOPMQtyShip
    {
        int SSSOPMQtyShipSp(string Job,
                            short? Suffix,
                            int? OperNum,
                            ref decimal? QtyShip,
                            ref string Infobar);
    }

    public class SSSOPMQtyShip : ISSSOPMQtyShip
    {
        readonly IApplicationDB appDB;

        public SSSOPMQtyShip(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSOPMQtyShipSp(string Job,
                                   short? Suffix,
                                   int? OperNum,
                                   ref decimal? QtyShip,
                                   ref string Infobar)
        {
            JobType _Job = Job;
            SuffixType _Suffix = Suffix;
            OperNumType _OperNum = OperNum;
            QtyUnitType _QtyShip = QtyShip;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSOPMQtyShipSp";

                appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyShip", _QtyShip, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                QtyShip = _QtyShip;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
