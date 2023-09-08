//PROJECT NAME: Data
//CLASS NAME: IAutoSyncCoFromPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAutoSyncCoFromPo
	{
		(int? ReturnCode,
			string Infobar) AutoSyncCoFromPoSp(
			string SourceSite,
			string DemandingSite,
			string DemandingPO,
			string Infobar);
	}
}

