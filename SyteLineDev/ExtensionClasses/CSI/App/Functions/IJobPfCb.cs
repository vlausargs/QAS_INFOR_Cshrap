//PROJECT NAME: Data
//CLASS NAME: IJobPfCb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobPfCb
	{
		(int? ReturnCode,
			string Infobar) JobPfCbSp(
			decimal? CurTransNum,
			string TWc,
			Guid? SessionId,
			int? pPostNeg,
			string Infobar,
			string DocumentNum = null);
	}
}

