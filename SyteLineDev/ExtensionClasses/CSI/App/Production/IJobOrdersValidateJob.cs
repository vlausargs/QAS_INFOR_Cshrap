//PROJECT NAME: Production
//CLASS NAME: IJobOrdersValidateJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobOrdersValidateJob
	{
		int? JobOrdersValidateJobSp(string PJob,
		int? PSuffix,
		string Infobar);
	}
}

