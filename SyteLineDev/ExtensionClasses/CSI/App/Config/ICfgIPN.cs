//PROJECT NAME: Config
//CLASS NAME: ICfgIPN.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgIPN
	{
		(int? ReturnCode,
			int? pIpn,
			string pNewItem,
			string Infobar) CfgIPNSp(
			string pCfgItem,
			string pConfigId,
			string pFirst,
			string pSecond,
			int? pIpn,
			string pNewItem,
			string Infobar);
	}
}

