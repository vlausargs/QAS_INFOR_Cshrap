//PROJECT NAME: Logistics
//CLASS NAME: IVoucherBuilderDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherBuilderDelete
	{
		int? VoucherBuilderDeleteSp(Guid? ProcessID,
		string Vend_Num = null);
	}
}

