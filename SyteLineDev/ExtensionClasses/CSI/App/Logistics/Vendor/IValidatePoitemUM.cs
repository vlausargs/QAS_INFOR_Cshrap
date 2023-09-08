//PROJECT NAME: Logistics
//CLASS NAME: IValidatePoitemUM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePoitemUM
	{
		(int? ReturnCode, string Infobar) ValidatePoitemUMSp(string UM,
		string VendNum,
		string Item,
		string Infobar);
	}
}

