//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroPlanTransPostMisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroPlanTransPostMisc
	{
		(int? ReturnCode, string Infobar) SSSFSSroPlanTransPostMiscSp(Guid? iRowPointer,
		string iMode,
		string iPartnerId,
		string iDept,
		string iWhse,
		DateTime? iTransDate,
		DateTime? iPostDate,
		decimal? iPstQty,
		decimal? iMatlCost,
		decimal? iLbrCost,
		decimal? iFovhdCost,
		decimal? iVovhdCost,
		decimal? iOutCost,
		string UpdateStatus,
		string Infobar);
	}
}

