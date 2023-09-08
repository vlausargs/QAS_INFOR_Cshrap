//PROJECT NAME: Logistics
//CLASS NAME: IValidatePayTypeAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePayTypeAll
	{
		(int? ReturnCode, string Infobar) ValidatePayTypeAllSp(string EntityPayType,
		string EntityCurrCode,
		string EntityBankCode,
		string Site,
		string Infobar);
	}
}

