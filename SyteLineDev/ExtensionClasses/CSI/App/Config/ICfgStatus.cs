//PROJECT NAME: Config
//CLASS NAME: ICfgStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgStatus
	{
		int? CfgStatusFn(
			string pConfigId);
	}
}

