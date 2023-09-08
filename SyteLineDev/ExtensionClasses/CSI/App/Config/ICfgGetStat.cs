//PROJECT NAME: Config
//CLASS NAME: ICfgGetStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetStat
	{
		(int? ReturnCode, string ConfigStatus,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Infobar) CfgGetStatSp(string TrnNum,
		int? TrnLine,
		string ConfigStatus,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Infobar);
	}
}

