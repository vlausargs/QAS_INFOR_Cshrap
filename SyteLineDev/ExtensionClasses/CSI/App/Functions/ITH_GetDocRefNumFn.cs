//PROJECT NAME: Data
//CLASS NAME: ITH_GetDocRefNumFn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITH_GetDocRefNumFn
	{
		string TH_GetDocRefNumFnFn(
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			decimal? TranNo);
	}
}

