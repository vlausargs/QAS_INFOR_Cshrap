//PROJECT NAME: Material
//CLASS NAME: ITransferOrderReceive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransferOrderReceive
	{
		(int? ReturnCode, string Infobar) TransferOrderReceiveSp(string TrnNum,
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
		string EmpNum = null,
		DateTime? RecordDate = null,
		string DocumentNum = null);
	}
}

