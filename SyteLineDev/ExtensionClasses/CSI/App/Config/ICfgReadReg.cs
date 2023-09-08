//PROJECT NAME: Config
//CLASS NAME: ICfgReadReg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgReadReg
	{
		(int? ReturnCode,
			string PKeyValue,
			string Infobar) CfgReadRegSp(
			string PKey,
			string PKeyValue,
			string Infobar);
	}
}

