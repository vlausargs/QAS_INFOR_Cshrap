//PROJECT NAME: Data
//CLASS NAME: IPreqDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPreqDel
	{
		(int? ReturnCode,
			string Infobar) PreqDelSp(
			string PreqitemReqNum,
			int? PreqitemReqLine,
			string PreqitemStat,
			string PreqitemPoNum,
			int? PreqitemPoLine,
			int? PreqitemPoRelease,
			string Infobar);
	}
}

