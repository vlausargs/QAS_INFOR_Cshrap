//PROJECT NAME: Material
//CLASS NAME: ITransferOrderReceiveSetVars.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransferOrderReceiveSetVars
	{
		(int? ReturnCode, string Infobar) TransferOrderReceiveSetVarsSp(string SET,
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
		string DocumentNum = null);
	}
}

