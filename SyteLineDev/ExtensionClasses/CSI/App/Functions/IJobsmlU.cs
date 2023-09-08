//PROJECT NAME: Data
//CLASS NAME: IJobsmlU.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobsmlU
	{
		(int? ReturnCode,
			string Infobar) JobsmlUSp(
			string Job,
			int? Suffix,
			string NewJob,
			int? NewSuffix,
			string Infobar);
	}
}

