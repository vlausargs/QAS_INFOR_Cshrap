//PROJECT NAME: Config
//CLASS NAME: ICfgCreateLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCreateLine
	{
		(int? ReturnCode,
			string Infobar) CfgCreateLineSp(
			string PConfigId,
			string Infobar);
	}
}

