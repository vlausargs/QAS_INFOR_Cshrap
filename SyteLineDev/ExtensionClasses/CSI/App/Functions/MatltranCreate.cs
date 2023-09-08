//PROJECT NAME: Data
//CLASS NAME: MatltranCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MatltranCreate : IMatltranCreate
	{
		readonly IApplicationDB appDB;
		
		public MatltranCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TransNum) MatltranCreateSp(
			Guid? BufferJournal = null,
			int? Update = 0,
			decimal? TransNum = null,
			string TransType = null,
			DateTime? TransDate = null,
			string Item = null,
			decimal? Qty = 0,
			string Whse = null,
			string Loc = null,
			string Lot = null,
			string RefType = null,
			string RefNum = null,
			int? RefLineSuf = 0,
			int? RefRelease = 0,
			string UserCode = null,
			string ReasonCode = null,
			int? Backflush = 0,
			string Wc = null,
			int? AwaitingEop = 0,
			decimal? Cost = 0,
			decimal? MatlCost = 0,
			decimal? LbrCost = 0,
			decimal? FovhdCost = 0,
			decimal? VovhdCost = 0,
			decimal? OutCost = 0,
			string CostCode = "0",
			Guid? RowPointer = null,
			string DocumentNum = null)
		{
			RowPointerType _BufferJournal = BufferJournal;
			IntType _Update = Update;
			MatlTransNumType _TransNum = TransNum;
			MatlTransTypeType _TransType = TransType;
			DateType _TransDate = TransDate;
			ItemType _Item = Item;
			QtyUnitType _Qty = Qty;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			RefTypeIJKOPRSTWType _RefType = RefType;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			UserCodeType _UserCode = UserCode;
			ReasonCodeType _ReasonCode = ReasonCode;
			ListYesNoType _Backflush = Backflush;
			WcType _Wc = Wc;
			ListYesNoType _AwaitingEop = AwaitingEop;
			CostPrcType _Cost = Cost;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostCodeType _CostCode = CostCode;
			RowPointerType _RowPointer = RowPointer;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MatltranCreateSp";
				
				appDB.AddCommandParameter(cmd, "BufferJournal", _BufferJournal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Update", _Update, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserCode", _UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Backflush", _Backflush, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AwaitingEop", _AwaitingEop, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransNum = _TransNum;
				
				return (Severity, TransNum);
			}
		}
	}
}
