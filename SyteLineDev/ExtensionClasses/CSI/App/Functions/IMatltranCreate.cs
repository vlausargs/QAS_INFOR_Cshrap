//PROJECT NAME: Data
//CLASS NAME: IMatltranCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMatltranCreate
	{
		(int? ReturnCode,
			decimal? TransNum) MatltranCreateSp(
			Guid? BufferJournal = null,
			int? Update = 0,
			decimal? TransNum = null,
			string TransType = null,
			DateTime? TransDate = null,
			string Item = null,
			decimal? Qty = 0,
			string Whse = null,
			string Loc = null,
			string Lot = null,
			string RefType = null,
			string RefNum = null,
			int? RefLineSuf = 0,
			int? RefRelease = 0,
			string UserCode = null,
			string ReasonCode = null,
			int? Backflush = 0,
			string Wc = null,
			int? AwaitingEop = 0,
			decimal? Cost = 0,
			decimal? MatlCost = 0,
			decimal? LbrCost = 0,
			decimal? FovhdCost = 0,
			decimal? VovhdCost = 0,
			decimal? OutCost = 0,
			string CostCode = "0",
			Guid? RowPointer = null,
			string DocumentNum = null);
	}
}

