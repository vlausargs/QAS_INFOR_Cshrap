//PROJECT NAME: Reporting
//CLASS NAME: IRpt_YearEndPayroll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_YearEndPayroll
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_YearEndPayrollSp(string ExBegDepart = null,
		string ExEndDepart = null,
		string ExBegEmp = null,
		string ExEndEmp = null,
		string ExOptdfEmplType = null,
		int? ExOptprPageBetween = null,
		DateTime? ExBegQuarter1 = null,
		DateTime? ExEndQuarter1 = null,
		DateTime? ExOptprQuarter2 = null,
		DateTime? ExOptprQuarter3 = null,
		DateTime? ExOptprQuarter4 = null,
		int? DateStartingOffSET = null,
		int? DateEndingOffSET = null,
		int? DateQuarter2OffSET = null,
		int? DateQuarter3OffSET = null,
		int? DateQuarter4OffSET = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null);
	}
}

