//PROJECT NAME: Data
//CLASS NAME: ILcrcpt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILcrcpt
	{
		(int? ReturnCode,
			string Infobar) LcrcptSp(
			string TrnitemTrnNum,
			int? TrnitemTrnLine,
			decimal? PQtyShipped,
			DateTime? PTranDate,
			string Infobar);
	}
}

