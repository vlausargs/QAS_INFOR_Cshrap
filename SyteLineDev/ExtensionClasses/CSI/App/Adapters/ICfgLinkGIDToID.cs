//PROJECT NAME: Adapters
//CLASS NAME: ICfgLinkGIDToID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Adapters
{
	public interface ICfgLinkGIDToID
	{
		(int? ReturnCode, string rConfigId,
		string Infobar) CfgLinkGIDToIDSp(string pItem,
		string pCoType,
		string pCoNum,
		int? pCoLine,
		int? pCoRelease,
		string pConfigGID,
		string rConfigId,
		string Infobar);
	}
}

