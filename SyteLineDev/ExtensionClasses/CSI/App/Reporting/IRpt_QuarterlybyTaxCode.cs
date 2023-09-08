//PROJECT NAME: Reporting
//CLASS NAME: IRpt_QuarterlybyTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_QuarterlybyTaxCode
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_QuarterlybyTaxCodeSp(DateTime? CheckDateStarting = null,
		DateTime? CheckDateEnding = null,
		string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		int? CheckDateStartingOffset = null,
		int? CheckDateEndingOffset = null,
		int? DisplayHeader = null,
		int? EmpTypeHourlyPerm = null,
		int? EmpTypeSalaryPerm = null,
		string pSite = null);
	}
}

