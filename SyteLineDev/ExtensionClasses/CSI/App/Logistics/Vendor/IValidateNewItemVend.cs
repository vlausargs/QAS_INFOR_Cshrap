//PROJECT NAME: Logistics
//CLASS NAME: IValidateNewItemVend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateNewItemVend
	{
		(int? ReturnCode, string Item,
		string Infobar) ValidateNewItemVendSp(string VendNum,
		string Item,
		string Infobar);
	}
}

