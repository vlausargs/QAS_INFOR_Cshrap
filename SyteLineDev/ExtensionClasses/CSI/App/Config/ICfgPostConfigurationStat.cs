//PROJECT NAME: Config
//CLASS NAME: ICfgPostConfigurationStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgPostConfigurationStat
	{
		string CfgPostConfigurationStatFn(
			string SourceRefType,
			string RefNum,
			int? RefLineSuf);
	}
}

