//PROJECT NAME: Production
//CLASS NAME: IJobRouteOperNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobRouteOperNum
	{
		(int? ReturnCode, string Infobar) JobRouteOperNumSp(string PJob,
		int? PSuffix,
		int? POperNum,
		string Infobar);
	}
}

