//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXDispValidRma.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXDispValidRma
    {
        int SSSRMXDispValidRmaSp(string Mode,
                                 string RmaNum,
                                 ref short? RmaLine,
                                 ref string RmaCustNum,
                                 ref int? RmaCustSeq,
                                 ref string CadName,
                                 ref string RmaStat,
                                 ref string RmaLnItem,
                                 ref decimal? RmaLnQtyToReturn,
                                 ref decimal? RmaLnQtyReceived,
                                 ref decimal? RmaLnQtyDispConv,
                                 ref string RmaLnStat,
                                 ref string RmxSerNum,
                                 ref string RmxDispCode,
                                 ref string DispCode,
                                 ref byte? RmxEnableDisp,
                                 ref byte? DerSerTracked,
                                 ref byte? DerLotTracked,
                                 ref string RmaWhse,
                                 ref string Loc,
                                 ref string Lot,
                                 ref decimal? Amount,
                                 ref string Infobar);
    }

    public class SSSRMXDispValidRma : ISSSRMXDispValidRma
    {
        readonly IApplicationDB appDB;

        public SSSRMXDispValidRma(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXDispValidRmaSp(string Mode,
                                        string RmaNum,
                                        ref short? RmaLine,
                                        ref string RmaCustNum,
                                        ref int? RmaCustSeq,
                                        ref string CadName,
                                        ref string RmaStat,
                                        ref string RmaLnItem,
                                        ref decimal? RmaLnQtyToReturn,
                                        ref decimal? RmaLnQtyReceived,
                                        ref decimal? RmaLnQtyDispConv,
                                        ref string RmaLnStat,
                                        ref string RmxSerNum,
                                        ref string RmxDispCode,
                                        ref string DispCode,
                                        ref byte? RmxEnableDisp,
                                        ref byte? DerSerTracked,
                                        ref byte? DerLotTracked,
                                        ref string RmaWhse,
                                        ref string Loc,
                                        ref string Lot,
                                        ref decimal? Amount,
                                        ref string Infobar)
        {
            StringType _Mode = Mode;
            RmaNumType _RmaNum = RmaNum;
            RmaLineType _RmaLine = RmaLine;
            CustNumType _RmaCustNum = RmaCustNum;
            CustSeqType _RmaCustSeq = RmaCustSeq;
            NameType _CadName = CadName;
            RmaStatusType _RmaStat = RmaStat;
            ItemType _RmaLnItem = RmaLnItem;
            QtyUnitType _RmaLnQtyToReturn = RmaLnQtyToReturn;
            QtyUnitType _RmaLnQtyReceived = RmaLnQtyReceived;
            QtyUnitType _RmaLnQtyDispConv = RmaLnQtyDispConv;
            RmaItemStatusType _RmaLnStat = RmaLnStat;
            SerNumType _RmxSerNum = RmxSerNum;
            RMXDispCodeType _RmxDispCode = RmxDispCode;
            RMXDispCodeType _DispCode = DispCode;
            ListYesNoType _RmxEnableDisp = RmxEnableDisp;
            ListYesNoType _DerSerTracked = DerSerTracked;
            ListYesNoType _DerLotTracked = DerLotTracked;
            WhseType _RmaWhse = RmaWhse;
            LocType _Loc = Loc;
            LotType _Lot = Lot;
            AmountType _Amount = Amount;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXDispValidRmaSp";

                appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaCustNum", _RmaCustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaCustSeq", _RmaCustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CadName", _CadName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaStat", _RmaStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaLnItem", _RmaLnItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaLnQtyToReturn", _RmaLnQtyToReturn, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaLnQtyReceived", _RmaLnQtyReceived, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaLnQtyDispConv", _RmaLnQtyDispConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaLnStat", _RmaLnStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmxSerNum", _RmxSerNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmxDispCode", _RmxDispCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DispCode", _DispCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmxEnableDisp", _RmxEnableDisp, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DerSerTracked", _DerSerTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DerLotTracked", _DerLotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RmaWhse", _RmaWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                RmaLine = _RmaLine;
                RmaCustNum = _RmaCustNum;
                RmaCustSeq = _RmaCustSeq;
                CadName = _CadName;
                RmaStat = _RmaStat;
                RmaLnItem = _RmaLnItem;
                RmaLnQtyToReturn = _RmaLnQtyToReturn;
                RmaLnQtyReceived = _RmaLnQtyReceived;
                RmaLnQtyDispConv = _RmaLnQtyDispConv;
                RmaLnStat = _RmaLnStat;
                RmxSerNum = _RmxSerNum;
                RmxDispCode = _RmxDispCode;
                DispCode = _DispCode;
                RmxEnableDisp = _RmxEnableDisp;
                DerSerTracked = _DerSerTracked;
                DerLotTracked = _DerLotTracked;
                RmaWhse = _RmaWhse;
                Loc = _Loc;
                Lot = _Lot;
                Amount = _Amount;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
