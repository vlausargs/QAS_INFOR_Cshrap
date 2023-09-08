//PROJECT NAME: Material
//CLASS NAME: ITransferLossSerialRefresh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransferLossSerialRefresh
	{
		(ICollectionLoadResponse Data, int? ReturnCode) TransferLossSerialRefreshSp(string PTrnNum,
		int? PTrnLine,
		string FROMSite,
		string ToSite,
		string Lot,
		decimal? TriQtyLoss,
		int? ItLotTracked,
		string Stat,
		string ImportDocId,
		int? ItTaxFreeMatl);
	}
}

