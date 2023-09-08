//PROJECT NAME: Production
//CLASS NAME: IApsOrderIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsOrderIns
	{
		int? ApsOrderInsSp(string OrdID,
		string Descr,
		string Cust,
		int? OrdTyp,
		string MatlID,
		decimal? OrdSiz,
		decimal? LodSiz,
		DateTime? ArivDate,
		DateTime? DueDate,
		DateTime? RequDate,
		int? Cat,
		string RefOrdID,
		string Whse,
		string PlanOnly,
		string SchedOnly,
		string AutoPlan,
		int? OrdFlags,
		string PartID,
		DateTime? RelDate,
		string ProcPlan,
		int? DerPassMfg,
		int? DerPassPur,
		int? DerDNInv,
		int? DerDNSup,
		int? DerRep,
		int? DerCoPr,
		int? DerDNAScrap,
		int? DerDNAMin,
		int? DerPullUp,
		int? DerRestr,
		int? DerStop,
		int? DerCross,
		int? DerFixSup,
		int? DerFixDem,
		int? AltNo,
		string OrderTable,
		Guid? RowPointer);
	}
}

