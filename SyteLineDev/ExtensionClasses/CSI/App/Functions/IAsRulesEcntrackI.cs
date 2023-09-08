//PROJECT NAME: Data
//CLASS NAME: IAsRulesEcntrackI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAsRulesEcntrackI
	{
		(int? ReturnCode,
			int? EcnTrack,
			string Infobar) AsRulesEcntrackISp(
			string Job,
			int? JobSuffix,
			string JobType,
			int? EcnTrack,
			string Infobar);
	}
}

