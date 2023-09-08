//PROJECT NAME: Config
//CLASS NAME: ICfgIPNCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgIPNCheck
	{
		(int? ReturnCode, int? pIpn,
		string pNewItem,
		string Infobar) CfgIPNCheckSp(string pConfigId,
		string pCEP,
		int? pIpn,
		string pNewItem,
		string CloneSite,
		string Infobar);
	}
}

