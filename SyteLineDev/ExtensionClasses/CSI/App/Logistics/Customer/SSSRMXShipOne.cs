//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXShipOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXShipOne
    {
        int SSSRMXShipOneSp(string RmaNum,
                            short? RmaLine,
                            int? TransNum,
                            decimal? Seq,
                            DateTime? ShipDate,
                            decimal? QtyToShipConv,
                            string Whse,
                            string Loc,
                            string Lot,
                            string UM,
                            string TransNat,
                            string Delterm,
                            string EcCode,
                            string Transport,
                            string Origin,
                            string CommCode,
                            decimal? SupplQty,
                            decimal? ExportValue,
                            decimal? UnitWeight,
                            int? ConsNum,
                            string ProcessInd,
                            decimal? Price,
                            ref string Infobar);
    }

    public class SSSRMXShipOne : ISSSRMXShipOne
    {
        readonly IApplicationDB appDB;

        public SSSRMXShipOne(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXShipOneSp(string RmaNum,
                                   short? RmaLine,
                                   int? TransNum,
                                   decimal? Seq,
                                   DateTime? ShipDate,
                                   decimal? QtyToShipConv,
                                   string Whse,
                                   string Loc,
                                   string Lot,
                                   string UM,
                                   string TransNat,
                                   string Delterm,
                                   string EcCode,
                                   string Transport,
                                   string Origin,
                                   string CommCode,
                                   decimal? SupplQty,
                                   decimal? ExportValue,
                                   decimal? UnitWeight,
                                   int? ConsNum,
                                   string ProcessInd,
                                   decimal? Price,
                                   ref string Infobar)
        {
            RmaNumType _RmaNum = RmaNum;
            RmaLineType _RmaLine = RmaLine;
            RMXTransNumType _TransNum = TransNum;
            RMXSeqType _Seq = Seq;
            DateType _ShipDate = ShipDate;
            QtyUnitType _QtyToShipConv = QtyToShipConv;
            WhseType _Whse = Whse;
            LocType _Loc = Loc;
            LotType _Lot = Lot;
            UMType _UM = UM;
            TransNatType _TransNat = TransNat;
            DeltermType _Delterm = Delterm;
            EcCodeType _EcCode = EcCode;
            TransportType _Transport = Transport;
            EcCodeType _Origin = Origin;
            CommodityCodeType _CommCode = CommCode;
            QtyPerNoNegType _SupplQty = SupplQty;
            AmountType _ExportValue = ExportValue;
            UnitWeightType _UnitWeight = UnitWeight;
            ConsignmentsType _ConsNum = ConsNum;
            ProcessIndType _ProcessInd = ProcessInd;
            CostPrcType _Price = Price;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXShipOneSp";

                appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipDate", _ShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyToShipConv", _QtyToShipConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Transport", _Transport, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplQty", _SupplQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExportValue", _ExportValue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ConsNum", _ConsNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
