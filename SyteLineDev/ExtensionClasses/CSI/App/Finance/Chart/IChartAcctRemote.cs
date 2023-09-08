//PROJECT NAME: Data
//CLASS NAME: IChartAcctRemote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chart
{
	public interface IChartAcctRemote
	{
		(int? ReturnCode,
			string Infobar) ChartAcctRemoteSp(
			string pMode,
			string pacct,
			string ptype,
			string pdescription,
			string preports_to_acct,
			DateTime? peff_date,
			DateTime? pobs_date,
			string paccess_unit1,
			string paccess_unit2,
			string paccess_unit3,
			string paccess_unit4,
			string pacct_class,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null,
			int? is_control = 0,
			string UETListPairs = null,
			string TransMethod = "N");
	}
}

