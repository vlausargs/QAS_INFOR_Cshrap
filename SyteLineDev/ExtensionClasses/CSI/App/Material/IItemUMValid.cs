//PROJECT NAME: Material
//CLASS NAME: IItemUMValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemUMValid
	{
		(int? ReturnCode, string PUM,
		decimal? UomConvFactor,
		string Infobar) ItemUMValidSp(string PItem,
		string PUM,
		decimal? UomConvFactor,
		string Infobar);
	}
}

