//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TaxVoucheredParametric.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TaxVoucheredParametric
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxVoucheredParametricSp(int? TaxJurTaxSystem = null,
		int? ExOptszShowDetail = null,
		string TaxJurTaxJur = null,
		DateTime? ExBegInvStaxInvDate = null,
		DateTime? ExENDInvStaxInvDate = null,
		int? ExOptgoInclVchPr = null,
		int? TAXDateStartingOffSET = null,
		int? TAXDateENDingOffSET = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null);
	}
}

