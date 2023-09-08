//PROJECT NAME: Config
//CLASS NAME: IGetCfgGroupName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface IGetCfgGroupName
	{
		(int? ReturnCode, string GroupName,
		string Infobar) GetCfgGroupNameSp(string UserName,
		string GroupName,
		string Infobar);
	}
}

