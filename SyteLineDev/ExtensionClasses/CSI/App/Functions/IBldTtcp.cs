//PROJECT NAME: Data
//CLASS NAME: IBldTtcp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBldTtcp
	{
		(int? ReturnCode,
			string Infobar) BldTtcpSp(
			string PItem,
			int? PDynLead,
			int? PAllJobs,
			int? PExclXref,
			int? pUseSchedTimesInPlanning,
			string pApsMode,
			string Infobar);
	}
}

