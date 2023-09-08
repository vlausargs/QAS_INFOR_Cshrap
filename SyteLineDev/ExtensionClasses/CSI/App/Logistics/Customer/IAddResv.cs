//PROJECT NAME: Logistics
//CLASS NAME: IAddResv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAddResv
	{
		(int? ReturnCode, decimal? RsvdNum,
		string Infobar) AddResvSp(string Item,
		string Whse,
		string RefNum,
		int? RefLine,
		int? RefRelease,
		string Loc,
		string Lot,
		decimal? Qty,
		decimal? ConvFactor,
		string UM,
		int? AutoRsvd,
		string ProgramName,
		decimal? RsvdNum,
		string Infobar,
		Guid? SessionID = null,
		string ImportDocId = null,
		string ParmsSite = null);
	}
}

