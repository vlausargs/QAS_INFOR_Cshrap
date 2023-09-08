//PROJECT NAME: Config
//CLASS NAME: ICfgReSetConfigId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgReSetConfigId
	{
		(int? ReturnCode, string ConfigGid) CfgReSetConfigIdSp(string ConfigEntryPoint,
		string Key1,
		string Key2,
		string Key3,
		string ConfigId,
		string ConfigGid,
		int? IsDocId = 0);
	}
}

