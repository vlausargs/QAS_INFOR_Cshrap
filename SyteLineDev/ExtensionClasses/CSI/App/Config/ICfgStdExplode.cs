//PROJECT NAME: Config
//CLASS NAME: ICfgStdExplode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgStdExplode
	{
		(int? ReturnCode,
			string Infobar) CfgStdExplodeSp(
			string pJobtype,
			string pRunMode,
			string pConfigId,
			string pJob,
			int? pSuffix,
			string Infobar,
			int? CalcSubJobDates = 0);
	}
}

