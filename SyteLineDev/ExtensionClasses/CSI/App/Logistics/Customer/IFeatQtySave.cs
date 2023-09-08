//PROJECT NAME: Logistics
//CLASS NAME: IFeatQtySave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IFeatQtySave
	{
		(int? ReturnCode, string Infobar) FeatQtySaveSp(string CoNum,
		int? CoLine,
		string Feature,
		string OptCode,
		decimal? MatlQtyConv,
		string UM,
		string Item,
		string Infobar);
	}
}

