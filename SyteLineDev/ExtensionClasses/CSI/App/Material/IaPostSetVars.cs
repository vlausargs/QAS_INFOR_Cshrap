//PROJECT NAME: Material
//CLASS NAME: IaPostSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class IaPostSetVars : IIaPostSetVars
	{
		IApplicationDB appDB;
		
		
		public IaPostSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? TotalCost,
		decimal? ProfitMarkup,
		string Infobar) IaPostSetVarsSp(string SET,
		string TrxType,
		DateTime? TransDate,
		string Acct = null,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null,
		decimal? TransQty = null,
		string Whse = null,
		string Item = null,
		string Loc = null,
		string Lot = null,
		string FromSite = null,
		string ToSite = null,
		string ReasonCode = null,
		string TrnNum = null,
		int? TrnLine = null,
		decimal? TransNum = null,
		decimal? RsvdNum = null,
		string SerialStat = "I",
		string Workkey = null,
		int? Override = 0,
		decimal? MatlCost = null,
		decimal? LbrCost = null,
		decimal? FovhdCost = null,
		decimal? VovhdCost = null,
		decimal? OutCost = null,
		decimal? TotalCost = null,
		decimal? ProfitMarkup = null,
		string Infobar = null,
		string ToWhse = null,
		string ToLoc = null,
		string ToLot = null,
		string TransferTrxType = null,
		Guid? TmpSerId = null,
		int? UseExistingSerials = null,
		string SerialPrefix = null,
		string RemoteSiteLot = null,
		string DocumentNum = null,
		string ImportDocId = null,
		int? MoveZeroCostItem = 0,
		string EmpNum = null,
		int? SkipItemlocDelete = 0,
		DateTime? FromSiteRecordDate = null,
		DateTime? ToSiteRecordDate = null)
		{
			ProcessIndType _SET = SET;
			StringType _TrxType = TrxType;
			DateType _TransDate = TransDate;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			QtyUnitType _TransQty = TransQty;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			ReasonCodeType _ReasonCode = ReasonCode;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			HugeTransNumType _TransNum = TransNum;
			RsvdNumType _RsvdNum = RsvdNum;
			SerialStatusType _SerialStat = SerialStat;
			StringType _Workkey = Workkey;
			ListYesNoType _Override = Override;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostPrcType _TotalCost = TotalCost;
			CostPrcType _ProfitMarkup = ProfitMarkup;
			InfobarType _Infobar = Infobar;
			WhseType _ToWhse = ToWhse;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			StringType _TransferTrxType = TransferTrxType;
			RowPointerType _TmpSerId = TmpSerId;
			ListYesNoType _UseExistingSerials = UseExistingSerials;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			ListExistingCreateBothType _RemoteSiteLot = RemoteSiteLot;
			DocumentNumType _DocumentNum = DocumentNum;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _MoveZeroCostItem = MoveZeroCostItem;
			EmpNumType _EmpNum = EmpNum;
			ListYesNoType _SkipItemlocDelete = SkipItemlocDelete;
			CurrentDateType _FromSiteRecordDate = FromSiteRecordDate;
			CurrentDateType _ToSiteRecordDate = ToSiteRecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IaPostSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxType", _TrxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransQty", _TransQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RsvdNum", _RsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialStat", _SerialStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Override", _Override, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalCost", _TotalCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProfitMarkup", _ProfitMarkup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferTrxType", _TransferTrxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLot", _RemoteSiteLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveZeroCostItem", _MoveZeroCostItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipItemlocDelete", _SkipItemlocDelete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSiteRecordDate", _FromSiteRecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSiteRecordDate", _ToSiteRecordDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovhdCost = _FovhdCost;
				VovhdCost = _VovhdCost;
				OutCost = _OutCost;
				TotalCost = _TotalCost;
				ProfitMarkup = _ProfitMarkup;
				Infobar = _Infobar;
				
				return (Severity, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, TotalCost, ProfitMarkup, Infobar);
			}
		}
	}
}
