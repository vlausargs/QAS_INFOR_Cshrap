//PROJECT NAME: Config
//CLASS NAME: ICfgMapConfiguration_Delete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgMapConfiguration_Delete
	{
		(int? ReturnCode, string Infobar) CfgMapConfiguration_DeleteSp(string TargetConfigID,
		string Infobar);
	}
}

