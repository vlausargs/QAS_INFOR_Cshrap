//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXFSPGetHeaderTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXFSPGetHeaderTaxCode
	{
		(int? ReturnCode,
			string oParentTaxCode,
			string Infobar) SSSVTXFSPGetHeaderTaxCodeSp(
			string pRefType,
			Guid? pHdrPtr,
			string pLineRefType,
			Guid? pLinePtr,
			string oParentTaxCode,
			string Infobar);
	}
}

