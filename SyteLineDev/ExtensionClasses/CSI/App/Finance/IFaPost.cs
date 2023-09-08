//PROJECT NAME: Finance
//CLASS NAME: IFaPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFaPost
	{
		(int? ReturnCode, decimal? DTot,
		int? XErrorCnt,
		string Infobar) FaPostSp(Guid? CurrFadistRowPointer,
		int? IsLastFadistFaNum,
		decimal? DTot,
		int? XErrorCnt,
		string Infobar);
	}
}

