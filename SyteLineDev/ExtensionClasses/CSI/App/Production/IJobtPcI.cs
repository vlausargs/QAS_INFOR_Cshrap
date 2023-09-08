//PROJECT NAME: Production
//CLASS NAME: IJobtPcI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtPcI
	{
		(int? ReturnCode, string Infobar) JobtPcISp(decimal? JobtClsJtTransNum,
		int? TCoby = null,
		string Infobar = null);
	}
}

