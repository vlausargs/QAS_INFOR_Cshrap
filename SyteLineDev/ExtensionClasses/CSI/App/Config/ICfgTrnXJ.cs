//PROJECT NAME: Config
//CLASS NAME: ICfgTrnXJ.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgTrnXJ
	{
		(int? ReturnCode,
			string Infobar) CfgTrnXJSp(
			string pTrnNum,
			int? pTrnLine,
			string pJob,
			int? pSuffix,
			string Infobar);
	}
}

