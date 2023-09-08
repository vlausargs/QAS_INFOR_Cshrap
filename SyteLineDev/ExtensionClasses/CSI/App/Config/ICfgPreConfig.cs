//PROJECT NAME: Config
//CLASS NAME: ICfgPreConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgPreConfig
	{
		(int? ReturnCode, string pItem,
		string CfgModel,
		string Infobar) CfgPreConfigSp(string pPermit,
		string pCep,
		string pItem,
		string CfgModel,
		string pCoNum,
		int? pCoLine,
		int? pCoRelease,
		string pJob,
		int? pSuffix,
		string pRunFrom,
		string ShipSite,
		string Infobar);
	}
}

