//PROJECT NAME: Material
//CLASS NAME: IPP_ItemUMConvert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPP_ItemUMConvert
	{
		(int? ReturnCode, string Infobar) PP_ItemUMConvertSp(decimal? Length,
		decimal? Width,
		decimal? Density,
		string BaseUM,
		string LengthUM,
		string DensityUM,
		string PaperMassBasis,
		string Item,
		string Infobar);
	}
}

