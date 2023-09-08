//PROJECT NAME: Logistics
//CLASS NAME: ICheckAPVoucherPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckAPVoucherPrint
	{
		(int? ReturnCode, string Infobar) CheckAPVoucherPrintSp(Guid? SessionID,
		string Infobar);
	}
}

