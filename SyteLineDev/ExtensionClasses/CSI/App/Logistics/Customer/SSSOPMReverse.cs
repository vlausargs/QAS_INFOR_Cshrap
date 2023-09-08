//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMReverse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSOPMReverse
    {
        int SSSOPMReverseSp(Guid? ip_ToShipRowPntr,
                            ref string Infobar);
    }

    public class SSSOPMReverse : ISSSOPMReverse
    {
        readonly IApplicationDB appDB;

        public SSSOPMReverse(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSOPMReverseSp(Guid? ip_ToShipRowPntr,
                                   ref string Infobar)
        {
            RowPointerType _ip_ToShipRowPntr = ip_ToShipRowPntr;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSOPMReverseSp";

                appDB.AddCommandParameter(cmd, "ip_ToShipRowPntr", _ip_ToShipRowPntr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
