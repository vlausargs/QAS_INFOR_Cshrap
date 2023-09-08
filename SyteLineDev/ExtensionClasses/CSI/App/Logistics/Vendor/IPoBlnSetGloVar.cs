//PROJECT NAME: Logistics
//CLASS NAME: IPoBlnSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoBlnSetGloVar
	{
		int? PoBlnSetGloVarSp(int? ItemVendAdd,
		int? ItemVendUpdate,
		int? PoChangeIup);
	}
}

