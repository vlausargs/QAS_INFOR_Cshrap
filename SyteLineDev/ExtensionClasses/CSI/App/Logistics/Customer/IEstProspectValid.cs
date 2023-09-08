//PROJECT NAME: Logistics
//CLASS NAME: IEstProspectValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstProspectValid
	{
		(int? ReturnCode, string Slsman,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		string PCur0AmtFormat,
		string Infobar,
		string BillToAddress,
		string TaxCode1,
		string TaxCode2,
		string Phone) EstProspectValidSp(string ProspectId,
		string Slsman,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		string PCur0AmtFormat,
		string Infobar,
		string BillToAddress,
		string TaxCode1 = null,
		string TaxCode2 = null,
		string Phone = null);
	}
}

