//PROJECT NAME: Data
//CLASS NAME: IJobCoCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobCoCopy
	{
		(int? ReturnCode,
			string Infobar) JobCoCopySp(
			string PJob,
			int? PSuffix,
			string PProdMix,
			string Infobar);
	}
}

