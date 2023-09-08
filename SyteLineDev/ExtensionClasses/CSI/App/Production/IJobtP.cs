//PROJECT NAME: Production
//CLASS NAME: IJobtP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtP
	{
		(int? ReturnCode,
			string Infobar) JobtPSp(
			string CallFrom,
			decimal? PTransNum,
			Guid? SessionId = null,
			Guid? RiJobtMat = null,
			string Infobar = null);
	}
}

