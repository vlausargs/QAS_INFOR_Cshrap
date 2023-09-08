//PROJECT NAME: Config
//CLASS NAME: ICfgRepConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgRepConfig
	{
		(int? ReturnCode,
			int? pOkFlag,
			string Infobar) CfgRepConfigSp(
			string pFromSite,
			string pToSite,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			string pTrnNum,
			int? pTrnLine,
			int? pOkFlag,
			string Infobar);
	}
}

