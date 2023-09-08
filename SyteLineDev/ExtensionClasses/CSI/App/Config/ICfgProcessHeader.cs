//PROJECT NAME: Config
//CLASS NAME: ICfgProcessHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgProcessHeader
	{
		(int? ReturnCode,
			string Infobar) CfgProcessHeaderSp(
			string pCoNum,
			string pType,
			string pRunMode,
			string Infobar);
	}
}

