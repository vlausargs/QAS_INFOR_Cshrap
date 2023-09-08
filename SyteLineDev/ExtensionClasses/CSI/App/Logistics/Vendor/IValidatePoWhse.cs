//PROJECT NAME: Logistics
//CLASS NAME: IValidatePoWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePoWhse
	{
		(int? ReturnCode, string Infobar) ValidatePoWhseSp(string PoNum,
		string CurWhse,
		string Infobar);
	}
}

