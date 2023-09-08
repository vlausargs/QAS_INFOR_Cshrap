//PROJECT NAME: Codes
//CLASS NAME: IGetTaxRegNumReturnSubmissionSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetTaxRegNumReturnSubmissionSite
	{
		(int? ReturnCode, string TaxRegNumReturnSubmissionSite) GetTaxRegNumReturnSubmissionSiteSp(string Site,
		string TaxRegNumReturnSubmissionSite);
	}
}

