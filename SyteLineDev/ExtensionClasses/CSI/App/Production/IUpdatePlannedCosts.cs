//PROJECT NAME: Production
//CLASS NAME: IUpdatePlannedCosts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IUpdatePlannedCosts
	{
		(int? ReturnCode, string Infobar) UpdatePlannedCostsSp(string PJob,
		int? PSuffix,
		string Infobar);
	}
}

