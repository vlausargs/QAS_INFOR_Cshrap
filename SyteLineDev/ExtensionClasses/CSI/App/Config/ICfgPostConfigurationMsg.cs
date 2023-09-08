//PROJECT NAME: Config
//CLASS NAME: ICfgPostConfigurationMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgPostConfigurationMsg
	{
		string CfgPostConfigurationMsgFn(
			string SourceRefType,
			string RefNum,
			int? RefLineSuf);
	}
}

