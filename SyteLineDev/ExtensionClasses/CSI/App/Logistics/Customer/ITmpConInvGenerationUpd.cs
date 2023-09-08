//PROJECT NAME: Logistics
//CLASS NAME: ITmpConInvGenerationUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITmpConInvGenerationUpd
	{
		int? TmpConInvGenerationUpdSp(Guid? SessionId,
		int? Selected,
		string CoNum,
		int? CoLine,
		int? CoRel,
		string CustPo,
		int? Consolidate,
		string InvFreq,
		DateTime? ShipDate,
		Guid? CoitemRowPointer,
		decimal? ShipmentId,
		string CoCustNum);
	}
}

