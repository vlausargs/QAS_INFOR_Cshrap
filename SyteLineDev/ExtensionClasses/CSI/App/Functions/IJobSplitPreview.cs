//PROJECT NAME: Data
//CLASS NAME: IJobSplitPreview.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobSplitPreview
	{
		(int? ReturnCode,
			string Infobar) JobSplitPreviewSp(
			string Job,
			int? Suffix,
			string NewJob,
			int? NewSuffix,
			decimal? OrigRelease,
			decimal? CurRelease,
			string Infobar);
	}
}

