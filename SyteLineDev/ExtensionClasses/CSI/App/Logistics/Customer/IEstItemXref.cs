//PROJECT NAME: Logistics
//CLASS NAME: IEstItemXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstItemXref
	{
		(int? ReturnCode, string CurRefNum,
		int? CurRefLineSuf,
		int? CurRefRelease,
		string Infobar) EstItemXrefSp(string EstNum,
		int? EstLine,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		decimal? QtyOrdered,
		DateTime? DueDate,
		string Whse,
		int? MpwxrefDelete = 0,
		int? CreateProj = 0,
		int? CreateProjtask = 0,
		string CurRefNum = null,
		int? CurRefLineSuf = null,
		int? CurRefRelease = null,
		string Infobar = null);
	}
}

