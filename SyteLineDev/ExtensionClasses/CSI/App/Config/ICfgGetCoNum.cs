//PROJECT NAME: Config
//CLASS NAME: ICfgGetCoNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetCoNum
	{
		(int? ReturnCode, string CoNum,
		int? CoLine,
		string Infobar) CfgGetCoNumSp(string ConfigId,
		string CoNum,
		int? CoLine,
		string Infobar);
	}
}

