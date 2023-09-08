//PROJECT NAME: Material
//CLASS NAME: TransferOrderReceiveSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TransferOrderReceiveSetVars : ITransferOrderReceiveSetVars
	{
		readonly IApplicationDB appDB;
		
		
		public TransferOrderReceiveSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TransferOrderReceiveSetVarsSp(string SET,
		string TrnNum,
		int? TrnLine,
		string Item,
		string FromSite,
		string FromWhse,
		string TrnLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string FobSite,
		string ToLoc,
		string ToLot,
		decimal? TQtyReceived,
		string TUM,
		DateTime? TTransDate,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		string Title,
		int? UseExistingSerials,
		string SerialPrefix,
		string PReasonCode,
		string Infobar,
		string ImportDocId = null,
		int? MoveZeroCostItem = null,
		DateTime? RecordDate = null,
		string DocumentNum = null)
		{
			ProcessIndType _SET = SET;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			ItemType _Item = Item;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			LocType _TrnLoc = TrnLoc;
			LotType _FromLot = FromLot;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			SiteType _FobSite = FobSite;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			QtyUnitType _TQtyReceived = TQtyReceived;
			UMType _TUM = TUM;
			DateType _TTransDate = TTransDate;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			LongListType _Title = Title;
			ListYesNoType _UseExistingSerials = UseExistingSerials;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			ReasonCodeType _PReasonCode = PReasonCode;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _MoveZeroCostItem = MoveZeroCostItem;
			CurrentDateType _RecordDate = RecordDate;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferOrderReceiveSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FobSite", _FobSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyReceived", _TQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
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
