//PROJECT NAME: Data
//CLASS NAME: ISumRma.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISumRma
	{
		(int? ReturnCode,
			decimal? RmaTotCredit,
			string Infobar) SumRmaSp(
			string PRmaNum,
			decimal? RmaTotCredit,
			string Infobar);
	}
}

