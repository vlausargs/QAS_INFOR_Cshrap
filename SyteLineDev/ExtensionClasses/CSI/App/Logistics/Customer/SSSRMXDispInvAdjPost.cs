//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispInvAdjPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDispInvAdjPost : ISSSRMXDispInvAdjPost
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXDispInvAdjPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Cost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar) SSSRMXDispInvAdjPostSp(
			string TrxType,
			string RmxType,
			DateTime? TransDate,
			Guid? DispCodeRowPointer,
			decimal? Qty,
			string Item,
			string Whse,
			string Loc,
			string Lot,
			string ReasonCode,
			string Stat,
			decimal? Cost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar,
			string Workkey = null,
			string RmaNum = null,
			int? RmaLine = null,
			int? RMXTransNum = null,
			decimal? RMXSeq = null,
			string DocumentNum = null)
		{
			DefaultCharType _TrxType = TrxType;
			DefaultCharType _RmxType = RmxType;
			DateType _TransDate = TransDate;
			RowPointerType _DispCodeRowPointer = DispCodeRowPointer;
			QtyUnitType _Qty = Qty;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ReasonCodeType _ReasonCode = ReasonCode;
			SerialStatusType _Stat = Stat;
			CostPrcType _Cost = Cost;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovCost = FovCost;
			CostPrcType _VovCost = VovCost;
			CostPrcType _OutCost = OutCost;
			Infobar _Infobar = Infobar;
			RefStrType _Workkey = Workkey;
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaLine = RmaLine;
			RMXTransNumType _RMXTransNum = RMXTransNum;
			RMXSeqType _RMXSeq = RMXSeq;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXDispInvAdjPostSp";
				
				appDB.AddCommandParameter(cmd, "TrxType", _TrxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmxType", _RmxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispCodeRowPointer", _DispCodeRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovCost", _FovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovCost", _VovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMXTransNum", _RMXTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMXSeq", _RMXSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Cost = _Cost;
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovCost = _FovCost;
				VovCost = _VovCost;
				OutCost = _OutCost;
				Infobar = _Infobar;
				
				return (Severity, Cost, MatlCost, LbrCost, FovCost, VovCost, OutCost, Infobar);
			}
		}
	}
}
