//PROJECT NAME: Config
//CLASS NAME: ICfgRefCheckDeleteWrapper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgRefCheckDeleteWrapper
	{
		(int? ReturnCode,
			string Infobar) CfgRefCheckDeleteWrapperSp(
			string CoNum,
			string Infobar);
	}
}

