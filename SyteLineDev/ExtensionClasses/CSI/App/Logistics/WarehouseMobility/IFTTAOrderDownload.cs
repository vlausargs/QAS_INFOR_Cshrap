//PROJECT NAME: Logistics
//CLASS NAME: IFTTAOrderDownload.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTTAOrderDownload
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTTAOrderDownloadSp(string OrderType,
		string OrderNumber,
		string Infobar);
	}
}

