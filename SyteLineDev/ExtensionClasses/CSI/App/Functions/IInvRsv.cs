//PROJECT NAME: Data
//CLASS NAME: IInvRsv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvRsv
	{
		(int? ReturnCode,
			decimal? QtyReserved,
			string Infobar) InvRsvSp(
			string Item,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? QtyToReserve,
			string Whse,
			string UM,
			string CustNum,
			string ProgramName,
			decimal? QtyReserved,
			string Infobar,
			string ParmsSite = null);
	}
}

