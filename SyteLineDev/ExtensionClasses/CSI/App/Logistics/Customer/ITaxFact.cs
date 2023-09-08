//PROJECT NAME: Logistics
//CLASS NAME: ITaxFact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITaxFact
	{
		(int? ReturnCode, decimal? PFactor,
		string Infobar) TaxFactSp(string PTermsCode,
		int? PUseExchRate,
		decimal? PExchRate,
		DateTime? PInvDate,
		string PCurrCode,
		decimal? PFactor,
		string Infobar,
		int? EXTGEN_TaxFactSp_Exists = null,
		string Site = null,
		string DomCurrCode = null);
	}
}

