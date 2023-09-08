//PROJECT NAME: Logistics
//CLASS NAME: ITmpCoShipUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITmpCoShipUpd
	{
		int? TmpCoShipUpdSp(Guid? RowPointer,
		int? Selected);
	}
}

