//PROJECT NAME: Data
//CLASS NAME: IItemCoJmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemCoJmatl
	{
		(int? ReturnCode,
			string Infobar) ItemCoJmatlSp(
			int? PValidate,
			int? PCalcVarFromStd,
			int? PTotalize,
			Guid? PJobmatlRowPointer,
			decimal? PJobQtyReleased,
			string PJob,
			int? PSuffix,
			string PItem,
			decimal? PScrapFact,
			int? POperNum,
			string Infobar);
	}
}

