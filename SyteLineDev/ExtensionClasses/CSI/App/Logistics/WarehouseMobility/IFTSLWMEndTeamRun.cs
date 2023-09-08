//PROJECT NAME: Logistics
//CLASS NAME: IFTSLWMEndTeamRun.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLWMEndTeamRun
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLWMEndTeamRunSp(string Infobar);
	}
}

