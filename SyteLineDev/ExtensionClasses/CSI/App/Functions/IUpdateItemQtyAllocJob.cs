//PROJECT NAME: Data
//CLASS NAME: IUpdateItemQtyAllocJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateItemQtyAllocJob
	{
		(int? ReturnCode,
			string Infobar) UpdateItemQtyAllocJobSp(
			string PAction,
			string PJob,
			int? PSuffix,
			string POldItem,
			string PNewItem,
			decimal? POldMatlQty,
			decimal? PNewMatlQty,
			string POldUM,
			string PNewUM,
			string POldUnits,
			string PNewUnits,
			decimal? POldScrapFact,
			decimal? PNewScrapFact,
			decimal? POldQtyIssued,
			decimal? PNewQtyIssued,
			int? PNewOperNum,
			int? POldOperNum,
			string Infobar);
	}
}

