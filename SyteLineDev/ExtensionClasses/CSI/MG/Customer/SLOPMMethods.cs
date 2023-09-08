//PROJECT NAME: CustomerExt
//CLASS NAME: SLOPMMethods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLOPMMethods")]
    public class SLOPMMethods : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSOPMQtyShipSp(string Job,
                                   short? Suffix,
                                   int? OperNum,
                                   ref decimal? QtyShip,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSOPMQtyShipExt = new SSSOPMQtyShipFactory().Create(appDb);

                int Severity = iSSSOPMQtyShipExt.SSSOPMQtyShipSp(Job,
                                                                 Suffix,
                                                                 OperNum,
                                                                 ref QtyShip,
                                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSOPMReverseSp(Guid? ip_ToShipRowPntr,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSOPMReverseExt = new SSSOPMReverseFactory().Create(appDb);

                int Severity = iSSSOPMReverseExt.SSSOPMReverseSp(ip_ToShipRowPntr,
                                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
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
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSOPMShipCheckExt = new SSSOPMShipCheckFactory().Create(appDb);

                int Severity = iSSSOPMShipCheckExt.SSSOPMShipCheckSp(ip_po_num,
                                                                     ip_po_line,
                                                                     ip_po_release,
                                                                     ip_ship_date,
                                                                     ip_qty_to_ship,
                                                                     ip_u_m,
                                                                     ip_trans_nat,
                                                                     ip_delterm,
                                                                     ip_ec_code,
                                                                     ip_transport,
                                                                     ip_origin,
                                                                     ip_comm_code,
                                                                     ip_suppl_qty,
                                                                     ip_export_value,
                                                                     ip_unit_weight,
                                                                     ip_cons_num,
                                                                     ip_process_ind,
                                                                     ip_price,
                                                                     ref op_RMXToShipRowPntr,
                                                                     ref op_qty_to_ship_base,
                                                                     ref op_Msg_Warn,
                                                                     ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSOPMShipOneSp(string ip_po_num,
                                   short? ip_po_line,
                                   short? ip_po_release,
                                   DateTime? ip_ship_date,
                                   decimal? ip_qty_to_ship,
                                   decimal? ip_qty_to_ship_base,
                                   Guid? ip_RMXToShipRowPntr,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSOPMShipOneExt = new SSSOPMShipOneFactory().Create(appDb);

                int Severity = iSSSOPMShipOneExt.SSSOPMShipOneSp(ip_po_num,
                                                                 ip_po_line,
                                                                 ip_po_release,
                                                                 ip_ship_date,
                                                                 ip_qty_to_ship,
                                                                 ip_qty_to_ship_base,
                                                                 ip_RMXToShipRowPntr,
                                                                 ref Infobar);

                return Severity;
            }
        }
    }
}
