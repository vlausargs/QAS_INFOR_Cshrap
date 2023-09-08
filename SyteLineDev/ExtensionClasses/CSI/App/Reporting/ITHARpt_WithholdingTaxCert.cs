//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_WithholdingTaxCert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_WithholdingTaxCert
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_WithholdingTaxCertSp(string BankCode,
		string BegVendNum = null,
		string EndVendNum = null,
		DateTime? BegCheckDate = null,
		DateTime? EndCheckDate = null,
		string BegName = null,
		string EndName = null,
		string Infobar = null,
		string pSite = null);
	}
}

