//PROJECT NAME: Config
//CLASS NAME: ICfgConfigurationIsOnHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgConfigurationIsOnHold
	{
		int? CfgConfigurationIsOnHoldFn(
			string SourceRefType,
			string RefNum,
			int? RefLineSuf);
	}
}

