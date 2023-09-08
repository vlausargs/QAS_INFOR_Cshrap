//PROJECT NAME: Reporting
//CLASS NAME: IRpt_YearToDateDeductionsandEarnings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_YearToDateDeductionsandEarnings
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_YearToDateDeductionsandEarningsSp(string ExBegDepart = null,
		string ExEndDepart = null,
		string ExBegEmp = null,
		string ExEndEmp = null,
		DateTime? ExBegCheckDate = null,
		DateTime? ExEndCheckDate = null,
		string ExOptdfEmplType = null,
		string ExBegPrdecdCode = null,
		string ExEndPrdecdCode = null,
		string ExOptdfDeCodeType = null,
		string ExOptprPrSortBy = null,
		int? DisplayHeader = null,
		int? DateStartingOffset = null,
		int? DateEndingOffset = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null);
	}
}

