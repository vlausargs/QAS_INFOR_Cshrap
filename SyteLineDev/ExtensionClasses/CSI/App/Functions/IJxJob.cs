//PROJECT NAME: Data
//CLASS NAME: IJxJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJxJob
	{
		(int? ReturnCode,
			string PAction,
			string Infobar) JxJobSp(
			string NextJob,
			int? NextSuffix,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PAction,
			string Infobar,
			string ExportType);
	}
}

