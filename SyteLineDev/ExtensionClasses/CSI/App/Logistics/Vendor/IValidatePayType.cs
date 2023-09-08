//PROJECT NAME: Logistics
//CLASS NAME: IValidatePayType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePayType
	{
		(int? ReturnCode, string Infobar) ValidatePayTypeSp(string EntityPayType,
		string EntityCurrCode,
		string EntityBankCode,
		string Infobar);
	}
}

