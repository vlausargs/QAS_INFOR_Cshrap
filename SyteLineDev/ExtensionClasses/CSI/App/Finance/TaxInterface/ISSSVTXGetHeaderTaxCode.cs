//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXGetHeaderTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXGetHeaderTaxCode
	{
		(int? ReturnCode,
			string oParentTaxCode,
			string Infobar) SSSVTXGetHeaderTaxCodeSp(
			string pRefType,
			Guid? pHdrPtr,
			string pLineRefType,
			Guid? pLinePtr,
			string pParentTaxCode,
			string oParentTaxCode,
			string Infobar);
	}
}

