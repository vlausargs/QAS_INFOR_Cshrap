//PROJECT NAME: Logistics
//CLASS NAME: ISupplUnitsConvFactorUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ISupplUnitsConvFactorUpdate
	{
		int? SupplUnitsConvFactorUpdateSp(string BegCommCode,
		string EndCommCode,
		int? UpdCoitem,
		int? UpdPoitem,
		int? UpdTrnitem,
		int? UpdRmaitem,
		int? UpdProjmatl);
	}
}

