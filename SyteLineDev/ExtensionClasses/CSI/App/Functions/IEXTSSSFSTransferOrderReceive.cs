//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSTransferOrderReceive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSTransferOrderReceive
	{
		(int? ReturnCode,
			string Infobar) EXTSSSFSTransferOrderReceiveSp(
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
			string ImportDocId = null);
	}
}

