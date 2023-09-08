//PROJECT NAME: Config
//CLASS NAME: ICfgDoConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgDoConfig
	{
		(int? ReturnCode, int? DoRefresh,
		string Infobar,
		int? Warning) CfgDoConfigSp(string pConfigId,
		string pCep,
		int? pCreateJob,
		string pRunFrom,
		string pRunMode,
		int? pUpdatePrice,
		int? DoRefresh,
		string Infobar,
		int? Warning);
	}
}

