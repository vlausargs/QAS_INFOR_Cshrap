//PROJECT NAME: Adapters
//CLASS NAME: ICfgCheckConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Adapters
{
	public interface ICfgCheckConfig
	{
		(int? ReturnCode, int? PConfigurable) CfgCheckConfigSp(string PCEP,
		string PItem,
		int? PConfigurable);

		int? CfgCheckConfigFn(
			string pCEP,
			string pItem);
	}
}

