//PROJECT NAME: Data
//CLASS NAME: ITrnitemUpdQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrnitemUpdQty
	{
		(int? ReturnCode,
			string Infobar) TrnitemUpdQtySp(
			string PTrnNum,
			int? PTrnLine,
			decimal? PQtyShipped,
			decimal? PQtyPacked,
			string PStat,
			DateTime? PShipDate,
			decimal? PQtyReceived,
			decimal? PQtyLoss,
			DateTime? PRcvdDate,
			string Infobar);
	}
}

