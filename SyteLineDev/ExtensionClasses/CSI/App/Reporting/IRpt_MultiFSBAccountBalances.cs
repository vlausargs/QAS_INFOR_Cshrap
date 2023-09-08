//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBAccountBalances.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBAccountBalances
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBAccountBalancesSp(DateTime? ExOptacAsOfDate = null,
		string ExStartingAccount = null,
		string ExEndingAccount = null,
		int? PUnitCode1 = 0,
		int? PUnitCode2 = 0,
		int? PUnitCode3 = 0,
		int? PUnitCode4 = 0,
		string UnitCode1Starting = null,
		string UnitCode1Ending = null,
		string UnitCode2Starting = null,
		string UnitCode2Ending = null,
		string UnitCode3Starting = null,
		string UnitCode3Ending = null,
		string UnitCode4Starting = null,
		string UnitCode4Ending = null,
		string ExOptacChartType = null,
		int? DateOffset = null,
		int? DisplayHeader = null,
		string FSBName = null,
		string pSite = null);
	}
}

