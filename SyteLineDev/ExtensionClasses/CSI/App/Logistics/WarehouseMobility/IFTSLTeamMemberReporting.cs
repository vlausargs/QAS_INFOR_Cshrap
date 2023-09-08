//PROJECT NAME: Logistics
//CLASS NAME: IFTSLTeamMemberReporting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLTeamMemberReporting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLTeamMemberReportingSp(string OrderNumber,
		int? Suffix,
		int? Operation,
		string Loc = null,
		string Lot = null);
	}
}

