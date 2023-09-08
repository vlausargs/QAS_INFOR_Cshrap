//PROJECT NAME: Config
//CLASS NAME: ICfgExplode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgExplode
	{
		(int? ReturnCode,
			string Infobar) CfgExplodeSp(
			string pJob,
			int? pSuffix,
			string pConfigId,
			string pJobType,
			string pRunMode,
			int? pUpdatePrice,
			string Infobar);
	}
}

