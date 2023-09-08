//PROJECT NAME: Data
//CLASS NAME: IPromotionPriceCal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPromotionPriceCal
	{
		(int? ReturnCode,
			decimal? PromotionPrice,
			string Infobar) PromotionPriceCalSp(
			string PromotionCode,
			decimal? PQtyOrdered,
			string PCurrCode,
			decimal? PUnitPrice,
			decimal? PromotionPrice,
			string CoNum = null,
			int? CoLine = null,
			string Infobar = null,
			string Site = null);
	}
}

