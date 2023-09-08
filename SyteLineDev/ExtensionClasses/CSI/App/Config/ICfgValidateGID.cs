//PROJECT NAME: Config
//CLASS NAME: ICfgValidateGID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgValidateGID
	{
		(int? ReturnCode, string Infobar) CfgValidateGIDSp(string pNewConfigGID,
		string Infobar);
	}
}

