//PROJECT NAME: Logistics
//CLASS NAME: IAptrxgPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAptrxgPost
	{
		(int? ReturnCode, string Infobar) AptrxgPostSp(Guid? PRecidAptrx,
		int? PCheck1,
		decimal? PSalesTax1,
		int? PCheck2,
		decimal? PSalesTax2,
		string Infobar);
	}
}

