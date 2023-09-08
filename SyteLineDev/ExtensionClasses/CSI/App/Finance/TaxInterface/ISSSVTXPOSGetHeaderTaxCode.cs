//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXPOSGetHeaderTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXPOSGetHeaderTaxCode
	{
		(int? ReturnCode,
			string oParentTaxCode,
			string Infobar) SSSVTXPOSGetHeaderTaxCodeSp(
			string pRefType,
			Guid? pHdrPtr,
			string pLineRefType,
			Guid? pLinePtr,
			string oParentTaxCode,
			string Infobar);
	}
}

