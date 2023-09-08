//PROJECT NAME: Config
//CLASS NAME: ICfgRemoveUnusedComps.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgRemoveUnusedComps
	{
		(int? ReturnCode, string Infobar) CfgRemoveUnusedCompsSp(string ConfigId,
		string CompGIDs,
		string Infobar);
	}
}

