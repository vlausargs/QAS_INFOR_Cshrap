//PROJECT NAME: Config
//CLASS NAME: ICfgPostConfigurationRequestID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgPostConfigurationRequestID
	{
		string CfgPostConfigurationRequestIDFn(
			string SourceRefType,
			string RefNum,
			int? RefLineSuf);
	}
}

