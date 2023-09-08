//PROJECT NAME: Logistics
//CLASS NAME: ITHAValidateTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITHAValidateTaxCode
	{
		(int? ReturnCode, string Infobar) THAValidateTaxCodeSp(string TaxCode,
		string Infobar);
	}
}

