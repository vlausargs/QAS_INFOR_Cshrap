//PROJECT NAME: Logistics
//CLASS NAME: IValidateAppmtdType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateAppmtdType
	{
		(int? ReturnCode, string Infobar) ValidateAppmtdTypeSp(string Type,
		string PayType,
		string Infobar);
	}
}

