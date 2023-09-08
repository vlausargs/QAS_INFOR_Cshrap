//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransSetItemPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransSetItemPrice
	{
		(int? ReturnCode, decimal? PriceConv,
		string Prompt,
		string PromptButtons,
		string Infobar) SSSFSSROTransSetItemPriceSp(string CalledFrom,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string Item,
		DateTime? TransDate,
		decimal? QtyConv,
		string BillCode,
		decimal? CostConv,
		decimal? PriceConv,
		string Prompt,
		string PromptButtons,
		string Infobar,
		string UM,
		string CustItem);
	}
}

