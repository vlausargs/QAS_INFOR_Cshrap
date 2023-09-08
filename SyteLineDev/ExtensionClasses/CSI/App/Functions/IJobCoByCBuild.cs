//PROJECT NAME: Data
//CLASS NAME: IJobCoByCBuild.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobCoByCBuild
	{
		(int? ReturnCode,
			string InfoBar) JobCoByCBuildSp(
			string PJobJob,
			int? PJobSuffix,
			int? PResetTT,
			string InfoBar = null);
	}
}

