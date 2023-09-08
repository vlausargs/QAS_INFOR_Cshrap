//PROJECT NAME: Data
//CLASS NAME: IPoapGv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoapGv
	{
		(int? ReturnCode,
			int? DateSeq,
			string Infobar) PoapGvSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			string Type,
			DateTime? PostDate,
			decimal? QtyReceived = 0,
			decimal? QtyReturned = 0,
			decimal? QtyVouchered = 0,
			decimal? ItemCost = null,
			decimal? ExchRate = null,
			int? Voucher = 0,
			string GrnNum = null,
			string PackNum = null,
			int? DateSeq = null,
			string Infobar = null);
	}
}

