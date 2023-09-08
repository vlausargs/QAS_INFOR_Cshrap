//PROJECT NAME: Config
//CLASS NAME: ICfgJobIsConfigurable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgJobIsConfigurable
	{
		int? CfgJobIsConfigurableFn(
			string CoitemCoNum,
			int? CoitemCoLine,
			int? CoitemCoRelease,
			string CoitemShipSite);
	}
}

