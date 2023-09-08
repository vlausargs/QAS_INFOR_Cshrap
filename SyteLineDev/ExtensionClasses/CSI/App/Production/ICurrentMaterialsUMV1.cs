//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsUMV1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsUMV1
	{
		(int? ReturnCode, decimal? MatlQtyConv,
		string VDerUM,
		decimal? VDerUOMConvFactor,
		decimal? VMatlQty,
		decimal? VCost,
		decimal? VIncPrice,
		decimal? VMatlCost,
		decimal? VLbrCost,
		decimal? VFovhdCost,
		decimal? VVovhdCost,
		decimal? VOutCost,
		string Infobar,
		string Prompt,
		string PromptButtons) CurrentMaterialsUMV1Sp(string UM,
		string Item,
		string ItemUM,
		decimal? Cost,
		decimal? IncPrice,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		string DerUM,
		decimal? MatlQtyConv,
		string VDerUM,
		decimal? VDerUOMConvFactor,
		decimal? VMatlQty,
		decimal? VCost,
		decimal? VIncPrice,
		decimal? VMatlCost,
		decimal? VLbrCost,
		decimal? VFovhdCost,
		decimal? VVovhdCost,
		decimal? VOutCost,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null);
	}
}

