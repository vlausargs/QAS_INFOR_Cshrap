//PROJECT NAME: Config
//CLASS NAME: ICfgUpdateConfigGid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgUpdateConfigGid
	{
		int? CfgUpdateConfigGidSp(string pRecType,
		string pKey1,
		string pKey2,
		string pKey3,
		string pConfigGid);
	}
}

