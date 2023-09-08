//PROJECT NAME: Config
//CLASS NAME: ICfgLineConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgLineConfig
	{
		(int? ReturnCode,
			string Infobar) CfgLineConfigSp(
			string pConfigId,
			string pNewItem,
			int? pUpdatePrice,
			string TrnNum,
			int? TrnLine,
			string Infobar);
	}
}

