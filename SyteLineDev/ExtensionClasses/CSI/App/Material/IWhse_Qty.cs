//PROJECT NAME: Material
//CLASS NAME: IWhse_Qty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IWhse_Qty
	{
		(int? ReturnCode,
			decimal? p_on_hand) Whse_QtySp(
			string p_mrp_whse,
			string p_whse,
			string p_item,
			decimal? p_on_hand);
	}
}

