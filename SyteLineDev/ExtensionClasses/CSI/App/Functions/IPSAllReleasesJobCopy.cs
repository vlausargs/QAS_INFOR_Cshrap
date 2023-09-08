//PROJECT NAME: Data
//CLASS NAME: IPSAllReleasesJobCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPSAllReleasesJobCopy
	{
		(int? ReturnCode,
			string Infobar) PSAllReleasesJobCopySp(
			string FromJob,
			int? FromSuffix,
			string FromType,
			string FromRevision,
			int? FromOperNumStart,
			int? FromOperNumEnd,
			string FromOpt,
			string Pjob,
			DateTime? EffectDate,
			string Infobar,
			int? CopyUetValues = 0);
	}
}

