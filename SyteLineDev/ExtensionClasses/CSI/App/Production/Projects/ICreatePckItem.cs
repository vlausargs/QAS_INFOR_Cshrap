//PROJECT NAME: Production
//CLASS NAME: ICreatePckItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICreatePckItem
	{
		(int? ReturnCode, string Infobar) CreatePckItemSp(int? PackNum,
		string ProjNum,
		int? TaskNum,
		int? Seq,
		string Item,
		string UM,
		decimal? PackQty,
		string Infobar);
	}
}

