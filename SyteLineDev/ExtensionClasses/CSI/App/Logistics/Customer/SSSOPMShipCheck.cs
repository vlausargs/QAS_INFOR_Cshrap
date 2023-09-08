//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMShipCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSOPMShipCheck
    {
        int SSSOPMShipCheckSp(string ip_po_num,
                              short? ip_po_line,
                              short? ip_po_release,
                              DateTime? ip_ship_date,
                              decimal? ip_qty_to_ship,
                              string ip_u_m,
                              string ip_trans_nat,
                              string ip_delterm,
                              string ip_ec_code,
                              string ip_transport,
                              string ip_origin,
                              string ip_comm_code,
                              decimal? ip_suppl_qty,
                              decimal? ip_export_value,
                              decimal? ip_unit_weight,
                              int? ip_cons_num,
                              string ip_process_ind,
                              decimal? ip_price,
                              ref Guid? op_RMXToShipRowPntr,
                              ref decimal? op_qty_to_ship_base,
                              ref string op_Msg_Warn,
                              ref string Infobar);
    }

    public class SSSOPMShipCheck : ISSSOPMShipCheck
    {
        readonly IApplicationDB appDB;

        public SSSOPMShipCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSOPMShipCheckSp(string ip_po_num,
                                     short? ip_po_line,
                                     short? ip_po_release,
                                     DateTime? ip_ship_date,
                                     decimal? ip_qty_to_ship,
                                     string ip_u_m,
                                     string ip_trans_nat,
                                     string ip_delterm,
                                     string ip_ec_code,
                                     string ip_transport,
                                     string ip_origin,
                                     string ip_comm_code,
                                     decimal? ip_suppl_qty,
                                     decimal? ip_export_value,
                                     decimal? ip_unit_weight,
                                     int? ip_cons_num,
                                     string ip_process_ind,
                                     decimal? ip_price,
                                     ref Guid? op_RMXToShipRowPntr,
                                     ref decimal? op_qty_to_ship_base,
                                     ref string op_Msg_Warn,
                                     ref string Infobar)
        {
            PoNumType _ip_po_num = ip_po_num;
            PoLineType _ip_po_line = ip_po_line;
            PoReleaseType _ip_po_release = ip_po_release;
            DateType _ip_ship_date = ip_ship_date;
            QtyUnitType _ip_qty_to_ship = ip_qty_to_ship;
            UMType _ip_u_m = ip_u_m;
            TransNatType _ip_trans_nat = ip_trans_nat;
            DeltermType _ip_delterm = ip_delterm;
            EcCodeType _ip_ec_code = ip_ec_code;
            TransportType _ip_transport = ip_transport;
            EcCodeType _ip_origin = ip_origin;
            CommodityCodeType _ip_comm_code = ip_comm_code;
            QtyPerNoNegType _ip_suppl_qty = ip_suppl_qty;
            AmountType _ip_export_value = ip_export_value;
            UnitWeightType _ip_unit_weight = ip_unit_weight;
            ConsignmentsType _ip_cons_num = ip_cons_num;
            ProcessIndType _ip_process_ind = ip_process_ind;
            CostPrcType _ip_price = ip_price;
            RowPointerType _op_RMXToShipRowPntr = op_RMXToShipRowPntr;
            QtyUnitType _op_qty_to_ship_base = op_qty_to_ship_base;
            InfobarType _op_Msg_Warn = op_Msg_Warn;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSOPMShipCheckSp";

                appDB.AddCommandParameter(cmd, "ip_po_num", _ip_po_num, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_po_line", _ip_po_line, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_po_release", _ip_po_release, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_ship_date", _ip_ship_date, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_qty_to_ship", _ip_qty_to_ship, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_u_m", _ip_u_m, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_trans_nat", _ip_trans_nat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_delterm", _ip_delterm, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_ec_code", _ip_ec_code, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_transport", _ip_transport, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_origin", _ip_origin, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_comm_code", _ip_comm_code, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_suppl_qty", _ip_suppl_qty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_export_value", _ip_export_value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_unit_weight", _ip_unit_weight, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_cons_num", _ip_cons_num, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_process_ind", _ip_process_ind, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ip_price", _ip_price, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "op_RMXToShipRowPntr", _op_RMXToShipRowPntr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "op_qty_to_ship_base", _op_qty_to_ship_base, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "op_Msg_Warn", _op_Msg_Warn, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                op_RMXToShipRowPntr = _op_RMXToShipRowPntr;
                op_qty_to_ship_base = _op_qty_to_ship_base;
                op_Msg_Warn = _op_Msg_Warn;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
