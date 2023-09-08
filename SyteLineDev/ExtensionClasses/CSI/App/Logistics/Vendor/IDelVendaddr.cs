//PROJECT NAME: Logistics
//CLASS NAME: IDelVendaddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IDelVendaddr
	{
		(int? ReturnCode, string Infobar) DelVendaddrSp(string VendNum,
		string Infobar);
	}
}

