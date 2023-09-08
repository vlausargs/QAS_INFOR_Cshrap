//PROJECT NAME: Data
//CLASS NAME: IJobCoByBuild.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobCoByBuild
	{
		(int? ReturnCode,
			string Infobar) JobCoByBuildSp(
			string JobJob,
			int? JobSuffix,
			string Infobar);
	}
}

