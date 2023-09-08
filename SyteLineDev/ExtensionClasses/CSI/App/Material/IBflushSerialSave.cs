//PROJECT NAME: Material
//CLASS NAME: IBflushSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBflushSerialSave
	{
		(int? ReturnCode, string Infobar) BflushSerialSaveSp(decimal? TransNum,
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
		string TransClass,
		int? TransSeq = null,
		string SerNum = null,
		string Infobar = null);
	}
}

