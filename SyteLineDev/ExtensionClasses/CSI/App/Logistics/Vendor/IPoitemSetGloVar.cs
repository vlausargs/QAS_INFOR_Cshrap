//PROJECT NAME: Logistics
//CLASS NAME: IPoitemSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoitemSetGloVar
	{
		int? PoitemSetGloVarSp(int? ItemVendAdd,
		int? ItemVendUpdate,
		int? PoChangeIup,
		int? AddProjMatl,
		string CostCode,
		int? UpdateJobMatlUnitCost);
	}
}

