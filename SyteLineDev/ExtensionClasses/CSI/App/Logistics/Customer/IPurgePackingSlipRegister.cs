//PROJECT NAME: Logistics
//CLASS NAME: IPurgePackingSlipRegister.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPurgePackingSlipRegister
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PurgePackingSlipRegisterSp(int? SPackNum,
		int? EPackNum,
		string Infobar);
	}
}

