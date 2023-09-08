//PROJECT NAME: Material
//CLASS NAME: TransferLossIaPostSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ITransferLossIaPostSetVars
	{
		(int? ReturnCode, string Infobar) TransferLossIaPostSetVarsSp(string SET,
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
		string FROMSite = null,
		string ToSite = null,
		string RemoteSite = null,
		string ReasonCode = null,
		string TrnNum = null,
		short? TrnLine = null,
		string Infobar = null,
		string ImportDocId = null,
		byte? MoveZeroCostItem = (byte)0,
		DateTime? RecordDate = null,
		string DocumentNum = null);
	}
	
	public class TransferLossIaPostSetVars : ITransferLossIaPostSetVars
	{
		readonly IApplicationDB appDB;
		
		public TransferLossIaPostSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TransferLossIaPostSetVarsSp(string SET,
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
		string FROMSite = null,
		string ToSite = null,
		string RemoteSite = null,
		string ReasonCode = null,
		string TrnNum = null,
		short? TrnLine = null,
		string Infobar = null,
		string ImportDocId = null,
		byte? MoveZeroCostItem = (byte)0,
		DateTime? RecordDate = null,
		string DocumentNum = null)
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
			SiteType _FROMSite = FROMSite;
			SiteType _ToSite = ToSite;
			SiteType _RemoteSite = RemoteSite;
			ReasonCodeType _ReasonCode = ReasonCode;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _MoveZeroCostItem = MoveZeroCostItem;
			CurrentDateType _RecordDate = RecordDate;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferLossIaPostSetVarsSp";
				
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
				appDB.AddCommandParameter(cmd, "FROMSite", _FROMSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSite", _RemoteSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveZeroCostItem", _MoveZeroCostItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
