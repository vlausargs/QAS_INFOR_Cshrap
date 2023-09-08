//PROJECT NAME: Data
//CLASS NAME: IJobBFlush.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobBFlush
	{
		(int? ReturnCode,
			DateTime? TDate,
			string CurWhse,
			decimal? TRouteQtyComplete,
			decimal? TRouteQtyScrapped,
			string TTransClass,
			string TEmpNum,
			decimal? TJobtranTransNum,
			string Infobar) JobBFlushSp(
			Guid? PJobRouteRp,
			string PJob,
			int? PSuffix,
			int? POper,
			decimal? PPhantomMulti,
			string PPhantomUnits,
			decimal? PPhantomScrap,
			string PBflushSetup,
			DateTime? TDate,
			string CurWhse,
			decimal? TRouteQtyComplete,
			decimal? TRouteQtyScrapped,
			string TTransClass,
			string TEmpNum,
			decimal? TJobtranTransNum,
			string Infobar);
	}
}

