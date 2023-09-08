//PROJECT NAME: Production
//CLASS NAME: IBuildListJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBuildListJob
	{
		(int? ReturnCode,
			decimal? PActual,
			decimal? PRemain,
			decimal? PPlanned) BuildListJobSp(
			string PJob = null,
			int? PSuffix = null,
			int? PIndent = null,
			decimal? PActual = null,
			decimal? PRemain = null,
			decimal? PPlanned = null);
	}
}

