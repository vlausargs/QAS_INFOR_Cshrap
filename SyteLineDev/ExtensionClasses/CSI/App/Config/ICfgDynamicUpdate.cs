//PROJECT NAME: Config
//CLASS NAME: ICfgDynamicUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgDynamicUpdate
	{
		(int? ReturnCode,
			string Infobar) CfgDynamicUpdateSp(
			string pFields,
			string pValues,
			string pRowPointer,
			string pTable,
			string Infobar);
	}
}

