//PROJECT NAME: Logistics
//CLASS NAME: IGenerateLCVouchersPostUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGenerateLCVouchersPostUpd
	{
		int? GenerateLCVouchersPostUpdSp(Guid? ProcessId);
	}
}

