//PROJECT NAME: Codes
//CLASS NAME: IGetTaxCodeDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetTaxCodeDefaults
	{
		(int? ReturnCode, string TaxCode1,
		string TaxCode2,
		int? TaxCodeFound,
		string Infobar) GetTaxCodeDefaultsSp(string Country = null,
		string State = null,
		string Zip = null,
		string TaxCode1 = null,
		string TaxCode2 = null,
		int? TaxCodeFound = 0,
		string Infobar = null);
	}
}

