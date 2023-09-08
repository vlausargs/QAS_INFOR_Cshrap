//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMShipOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSOPMShipOne
    {
        int SSSOPMShipOneSp(string ip_po_num,
                            short? ip_po_line,
                            short? ip_po_release,
                            DateTime? ip_ship_date,
                            decimal? ip_qty_to_ship,
                            decimal? ip_qty_to_ship_base,
                            Guid? ip_RMXToShipRowPntr,
                            ref string Infobar);
    }

    public class SSSOPMShipOne : ISSSOPMShipOne
    {
        readonly IApplicationDB appDB;

        public SSSOPMShipOne(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSOPMShipOneSp(string ip_po_num,
                                   short? ip_po_line,
                                   short? ip_po_release,
                                   DateTime? ip_ship_date,
                                   decimal? ip_qty_to_ship,
                                   decimal? ip_qty_to_ship_base,
                                   Guid? ip_RMXToShipRowPntr,
                                   ref string Infobar)
        {
            PoNumType _ip_po_num = ip_po_num;
            PoLineType _ip_po_line = ip_po_line;
            PoReleaseType _ip_po_release = ip_po_release;
            DateType _ip_ship_date = ip_ship_date;
            QtyUnitType _ip_qty_to_ship = ip_qty_to_ship;
            QtyUnitType _ip_qty_to_ship_base = ip_qty_to_ship_base;
            RowPointerType _ip_RMXToShipRowPntr = ip_RMXToShipRowPntr;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSOPMShipOneSp";

                appDB.AddCommandParameter(cmd, "ip_po_num", _ip_po_num, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_po_line", _ip_po_line, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_po_release", _ip_po_release, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_ship_date", _ip_ship_date, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_qty_to_ship", _ip_qty_to_ship, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_qty_to_ship_base", _ip_qty_to_ship_base, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_RMXToShipRowPntr", _ip_RMXToShipRowPntr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
