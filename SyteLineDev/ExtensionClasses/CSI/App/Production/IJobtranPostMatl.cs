//PROJECT NAME: Production
//CLASS NAME: IJobtranPostMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtranPostMatl
	{
		(int? ReturnCode,
			string Infobar) JobtranPostMatlSp(
			Guid? SessionID,
			decimal? JobtranTransNum,
			string CallFrom = null,
			int? Coby = null,
			int? CreateMatPost = 0,
			string Infobar = null);
	}
}

