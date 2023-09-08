//PROJECT NAME: Logistics
//CLASS NAME: IFTSLTAGetResourceId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLTAGetResourceId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLTAGetResourceIdSp(int? DisplayResourceId,
		int? OnlyAllowResource,
		string Job,
		int? Suffix,
		int? Operation);
	}
}

