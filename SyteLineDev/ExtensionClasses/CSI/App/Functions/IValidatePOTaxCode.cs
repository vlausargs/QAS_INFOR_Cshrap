//PROJECT NAME: Data
//CLASS NAME: IValidatePOTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidatePOTaxCode
	{
		(int? ReturnCode,
			string Infobar) ValidatePOTaxCodeSp(
			int? TaxSystem,
			string TaxCode,
			string TaxArea,
			string Infobar);
	}
}

