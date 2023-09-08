//PROJECT NAME: Logistics
//CLASS NAME: INextBuilderVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface INextBuilderVoucher
	{
		(int? ReturnCode, string Key,
		string Infobar) NextBuilderVoucherSp(string Key,
		string Infobar);
	}
}

