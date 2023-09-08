//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXShipRevOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXShipRevOne
    {
        int SSSRMXShipRevOneSp(Guid? ToShipRowPointer,
                               DateTime? ShipDate,
                               ref string Infobar);
    }

    public class SSSRMXShipRevOne : ISSSRMXShipRevOne
    {
        readonly IApplicationDB appDB;

        public SSSRMXShipRevOne(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXShipRevOneSp(Guid? ToShipRowPointer,
                                      DateTime? ShipDate,
                                      ref string Infobar)
        {
            RowPointerType _ToShipRowPointer = ToShipRowPointer;
            DateType _ShipDate = ShipDate;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXShipRevOneSp";

                appDB.AddCommandParameter(cmd, "ToShipRowPointer", _ToShipRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipDate", _ShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
