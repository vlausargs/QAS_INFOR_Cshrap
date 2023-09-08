//PROJECT NAME: Config
//CLASS NAME: ICfgCopyConfigCfgRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCopyConfigCfgRef
	{
		(int? ReturnCode,
			string Infobar) CfgCopyConfigCfgRefSp(
			string pOldConfigID,
			string pNewCoNum,
			int? pNewCoLine,
			int? pNewCoRelease,
			string pNewJob,
			int? pNewSuffix,
			string pNewItem,
			string pNewConfigGid,
			string pConfigurator,
			string Infobar);
	}
}

