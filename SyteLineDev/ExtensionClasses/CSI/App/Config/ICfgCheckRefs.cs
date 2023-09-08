//PROJECT NAME: Config
//CLASS NAME: ICfgCheckRefs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCheckRefs
	{
		(int? ReturnCode, int? PReconfigOk,
		string Infobar) CfgCheckRefsSp(string PConfigId,
		int? PJobFlag,
		int? PReconfigOk,
		string Infobar);
	}
}

