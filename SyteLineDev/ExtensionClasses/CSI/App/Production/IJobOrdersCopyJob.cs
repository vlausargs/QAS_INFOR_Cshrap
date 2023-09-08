//PROJECT NAME: Production
//CLASS NAME: IJobOrdersCopyJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobOrdersCopyJob
	{
		(int? ReturnCode, string PJob,
		int? PSuffix,
		string Infobar) JobOrdersCopyJobSp(string PJob,
		int? PSuffix,
		string JobItem,
		string JobRevision,
		string Infobar);
	}
}

