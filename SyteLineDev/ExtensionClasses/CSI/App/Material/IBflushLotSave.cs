//PROJECT NAME: Material
//CLASS NAME: IBflushLotSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBflushLotSave
	{
		(int? ReturnCode, string Infobar) BflushLotSaveSp(decimal? TransNum,
		string Whse,
		string Lot,
		int? Selected,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string EmpNum,
		string JobMatlItem,
		string Loc,
		decimal? QtyNeeded,
		decimal? QtyRequired,
		string JobRouteWc,
		string UM,
		string TransClass,
		int? TransSeq = null,
		string Infobar = null,
		Guid? SessionId = null);
	}
}

