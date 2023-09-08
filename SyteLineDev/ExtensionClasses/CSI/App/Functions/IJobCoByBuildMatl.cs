//PROJECT NAME: Data
//CLASS NAME: IJobCoByBuildMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobCoByBuildMatl
	{
		(int? ReturnCode,
			string Infobar) JobCoByBuildMatlSp(
			Guid? JobmatlRowPointer,
			string ProdMixItemItem,
			string JobrouteJob,
			int? JobrouteSuffix,
			int? JobrouteOperNum,
			decimal? ReleasedQty,
			decimal? ScrapFact,
			int? Totalize,
			int? Validate,
			int? CalcVarFromStd,
			string Infobar);
	}
}

