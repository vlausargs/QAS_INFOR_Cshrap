//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXRtnReceipt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXRtnReceipt : ISSSRMXRtnReceipt
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXRtnReceipt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? MatltrackNum,
			string Infobar) SSSRMXRtnReceiptSp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			decimal? Qty,
			string RmaNum,
			int? RmaLine,
			DateTime? TransDate,
			string ReasonCode,
			string VendNum,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			int? Reverse,
			string JourRec,
			string JourRecPrefix,
			string JourRecHd,
			string InvvendMatlAcct,
			string InvvendMatlAcctUnit1,
			string InvvendMatlAcctUnit2,
			string InvvendMatlAcctUnit3,
			string InvvendMatlAcctUnit4,
			string InvvendLbrAcct,
			string InvvendLbrAcctUnit1,
			string InvvendLbrAcctUnit2,
			string InvvendLbrAcctUnit3,
			string InvvendLbrAcctUnit4,
			string InvvendFovAcct,
			string InvvendFovAcctUnit1,
			string InvvendFovAcctUnit2,
			string InvvendFovAcctUnit3,
			string InvvendFovAcctUnit4,
			string InvvendVovAcct,
			string InvvendVovAcctUnit1,
			string InvvendVovAcctUnit2,
			string InvvendVovAcctUnit3,
			string InvvendVovAcctUnit4,
			string InvvendOutAcct,
			string InvvendOutAcctUnit1,
			string InvvendOutAcctUnit2,
			string InvvendOutAcctUnit3,
			string InvvendOutAcctUnit4,
			decimal? MatltrackNum,
			string Infobar,
			int? TmpSer = 0,
			int? UpdateCGS = 0,
			string Workkey = null,
			string ProcessType = "V",
			decimal? MatlTranAmtMatlAmt = 0,
			decimal? MatltranAmtLbrAmt = 0,
			decimal? MatltranAmtFovhdAmt = 0,
			decimal? MatltranAmtVovhdAmt = 0,
			decimal? MatlTranAmtOutAmt = 0,
			Guid? RmaitemRowPointer = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitType _Qty = Qty;
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaLine = RmaLine;
			DateType _TransDate = TransDate;
			ReasonCodeType _ReasonCode = ReasonCode;
			VendNumType _VendNum = VendNum;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovCost = FovCost;
			CostPrcType _VovCost = VovCost;
			CostPrcType _OutCost = OutCost;
			ListYesNoType _Reverse = Reverse;
			DescriptionType _JourRec = JourRec;
			DescriptionType _JourRecPrefix = JourRecPrefix;
			DescriptionType _JourRecHd = JourRecHd;
			AcctType _InvvendMatlAcct = InvvendMatlAcct;
			UnitCode1Type _InvvendMatlAcctUnit1 = InvvendMatlAcctUnit1;
			UnitCode2Type _InvvendMatlAcctUnit2 = InvvendMatlAcctUnit2;
			UnitCode3Type _InvvendMatlAcctUnit3 = InvvendMatlAcctUnit3;
			UnitCode4Type _InvvendMatlAcctUnit4 = InvvendMatlAcctUnit4;
			AcctType _InvvendLbrAcct = InvvendLbrAcct;
			UnitCode1Type _InvvendLbrAcctUnit1 = InvvendLbrAcctUnit1;
			UnitCode2Type _InvvendLbrAcctUnit2 = InvvendLbrAcctUnit2;
			UnitCode3Type _InvvendLbrAcctUnit3 = InvvendLbrAcctUnit3;
			UnitCode4Type _InvvendLbrAcctUnit4 = InvvendLbrAcctUnit4;
			AcctType _InvvendFovAcct = InvvendFovAcct;
			UnitCode1Type _InvvendFovAcctUnit1 = InvvendFovAcctUnit1;
			UnitCode2Type _InvvendFovAcctUnit2 = InvvendFovAcctUnit2;
			UnitCode3Type _InvvendFovAcctUnit3 = InvvendFovAcctUnit3;
			UnitCode4Type _InvvendFovAcctUnit4 = InvvendFovAcctUnit4;
			AcctType _InvvendVovAcct = InvvendVovAcct;
			UnitCode1Type _InvvendVovAcctUnit1 = InvvendVovAcctUnit1;
			UnitCode2Type _InvvendVovAcctUnit2 = InvvendVovAcctUnit2;
			UnitCode3Type _InvvendVovAcctUnit3 = InvvendVovAcctUnit3;
			UnitCode4Type _InvvendVovAcctUnit4 = InvvendVovAcctUnit4;
			AcctType _InvvendOutAcct = InvvendOutAcct;
			UnitCode1Type _InvvendOutAcctUnit1 = InvvendOutAcctUnit1;
			UnitCode2Type _InvvendOutAcctUnit2 = InvvendOutAcctUnit2;
			UnitCode3Type _InvvendOutAcctUnit3 = InvvendOutAcctUnit3;
			UnitCode4Type _InvvendOutAcctUnit4 = InvvendOutAcctUnit4;
			MatlTransNumType _MatltrackNum = MatltrackNum;
			Infobar _Infobar = Infobar;
			ListYesNoType _TmpSer = TmpSer;
			ListYesNoType _UpdateCGS = UpdateCGS;
			LongListType _Workkey = Workkey;
			StringType _ProcessType = ProcessType;
			CostPrcType _MatlTranAmtMatlAmt = MatlTranAmtMatlAmt;
			CostPrcType _MatltranAmtLbrAmt = MatltranAmtLbrAmt;
			CostPrcType _MatltranAmtFovhdAmt = MatltranAmtFovhdAmt;
			CostPrcType _MatltranAmtVovhdAmt = MatltranAmtVovhdAmt;
			CostPrcType _MatlTranAmtOutAmt = MatlTranAmtOutAmt;
			RowPointerType _RmaitemRowPointer = RmaitemRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXRtnReceiptSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovCost", _FovCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovCost", _VovCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reverse", _Reverse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JourRec", _JourRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JourRecPrefix", _JourRecPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JourRecHd", _JourRecHd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendMatlAcct", _InvvendMatlAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendMatlAcctUnit1", _InvvendMatlAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendMatlAcctUnit2", _InvvendMatlAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendMatlAcctUnit3", _InvvendMatlAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendMatlAcctUnit4", _InvvendMatlAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendLbrAcct", _InvvendLbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendLbrAcctUnit1", _InvvendLbrAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendLbrAcctUnit2", _InvvendLbrAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendLbrAcctUnit3", _InvvendLbrAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendLbrAcctUnit4", _InvvendLbrAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendFovAcct", _InvvendFovAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendFovAcctUnit1", _InvvendFovAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendFovAcctUnit2", _InvvendFovAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendFovAcctUnit3", _InvvendFovAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendFovAcctUnit4", _InvvendFovAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendVovAcct", _InvvendVovAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendVovAcctUnit1", _InvvendVovAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendVovAcctUnit2", _InvvendVovAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendVovAcctUnit3", _InvvendVovAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendVovAcctUnit4", _InvvendVovAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendOutAcct", _InvvendOutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendOutAcctUnit1", _InvvendOutAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendOutAcctUnit2", _InvvendOutAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendOutAcctUnit3", _InvvendOutAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvvendOutAcctUnit4", _InvvendOutAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltrackNum", _MatltrackNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TmpSer", _TmpSer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateCGS", _UpdateCGS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessType", _ProcessType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlTranAmtMatlAmt", _MatlTranAmtMatlAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranAmtLbrAmt", _MatltranAmtLbrAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranAmtFovhdAmt", _MatltranAmtFovhdAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranAmtVovhdAmt", _MatltranAmtVovhdAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlTranAmtOutAmt", _MatlTranAmtOutAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaitemRowPointer", _RmaitemRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatltrackNum = _MatltrackNum;
				Infobar = _Infobar;
				
				return (Severity, MatltrackNum, Infobar);
			}
		}
	}
}
