//PROJECT NAME: Logistics
//CLASS NAME: IValidateSalesTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateSalesTax
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateSalesTaxSp(int? PTaxSystem,
		string PTaxCode,
		decimal? PTaxBasis,
		string PVendNum,
		decimal? PSalesTax,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

