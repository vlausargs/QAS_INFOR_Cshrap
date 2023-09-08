//PROJECT NAME: Data
//CLASS NAME: IJobCoByBuildPhantom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobCoByBuildPhantom
	{
		(int? ReturnCode,
			string Infobar) JobCoByBuildPhantomSp(
			string JobmatlJob,
			int? JobmatlSuffix,
			string ProdMixItemItem,
			string JobrouteJob,
			int? JobrouteSuffix,
			int? JobrouteOperNum,
			decimal? ReleasedQty,
			decimal? ScrapFact,
			int? Totalize,
			string Infobar);
	}
}

