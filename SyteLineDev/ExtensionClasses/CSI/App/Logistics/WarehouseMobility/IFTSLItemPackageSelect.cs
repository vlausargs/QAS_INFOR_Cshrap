//PROJECT NAME: Logistics
//CLASS NAME: IFTSLItemPackageSelect.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLItemPackageSelect
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) FTSLItemPackageSelectSp(decimal? ShipmentId,
		int? PackageId,
		string ERPQueryResponseString,
		string Infobar);
	}
}

