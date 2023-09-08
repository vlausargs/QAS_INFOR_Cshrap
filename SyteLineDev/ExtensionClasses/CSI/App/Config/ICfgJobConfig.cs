//PROJECT NAME: Config
//CLASS NAME: ICfgJobConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgJobConfig
	{
		(int? ReturnCode, string pJob,
		int? pSuffix,
		string CurWhse,
		string Infobar) CfgJobConfigSp(int? pCreateJob,
		string pFrom,
		string pJobtype,
		string pConfigId,
		string pCfgItem,
		string pCoNum,
		int? pCoLine,
		int? pCoRel,
		string pJob,
		int? pSuffix,
		string CurWhse,
		string Infobar,
		int? DelJobNote = 1);
	}
}

