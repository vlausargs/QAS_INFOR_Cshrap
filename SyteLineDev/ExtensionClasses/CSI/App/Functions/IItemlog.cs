//PROJECT NAME: Data
//CLASS NAME: IItemlog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemlog
	{
		(int? ReturnCode,
			string Infobar) ItemlogSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string PItem,
			string OldItem,
			decimal? POldQty,
			decimal? PNewQty,
			decimal? POldPrice,
			decimal? PNewPrice,
			decimal? POldDisc,
			decimal? PNewDisc,
			decimal? POldCoDisc,
			decimal? PNewCoDisc,
			DateTime? POldDueDate,
			DateTime? PNewDueDate,
			DateTime? POldProjectedDate,
			DateTime? PNewProjectedDate,
			string PAction,
			decimal? PUomConvFactor,
			string POldUm,
			string PNewUm,
			string Infobar);
	}
}

