//PROJECT NAME: Logistics
//CLASS NAME: IGetShipmentList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetShipmentList
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) GetShipmentListSp(decimal? PickListId,
		string InfoBar);
	}
}

