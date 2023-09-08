//PROJECT NAME: Config
//CLASS NAME: ICfgPostConfigurationQueueType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgPostConfigurationQueueType
	{
		string CfgPostConfigurationQueueTypeFn(
			string SourceRefType,
			string RefNum,
			int? RefLineSuf);
	}
}

