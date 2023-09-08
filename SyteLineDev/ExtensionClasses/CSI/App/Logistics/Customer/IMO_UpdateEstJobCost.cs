//PROJECT NAME: Logistics
//CLASS NAME: IMO_UpdateEstJobCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IMO_UpdateEstJobCost
	{
		(int? ReturnCode, string Infobar) MO_UpdateEstJobCostSp(string Job,
		int? JobSuffix,
		string Infobar);
	}
}

